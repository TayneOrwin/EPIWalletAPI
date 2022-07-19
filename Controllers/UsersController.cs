using EPIWalletAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //reference for User and User identity
        // //https://www.youtube.com/watch?v=CzRM-hOe35o&ab_channel=CodAffection


        //Add These
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicatonSettings _appSettings;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            IOptions<ApplicatonSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }
        //

        [HttpPost]
        [Route("Register")]
        //POST : /api/User/Register
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            var checkUser = await _userManager.FindByEmailAsync(model.Email);
            if (checkUser != null)
            {
                return Ok(new { code = 401, message = "User Already Exists !!!!!" });
            }
            else
            {
                var applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                };

                try
                {
                    var result = await _userManager.CreateAsync(applicationUser, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok(new { code = 200 });
                    }
                    else
                    {
                        return Ok(new { code = 401, message = "Unable To Register User" });
                    }
                }
                catch (Exception ex)
                {

                    return Ok(new { code = 401, message = ex.ToString() });
                }
            }

        }
            [HttpPost]
        [Route("Login")]
        //POST : /api/User/Login
        public  async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var PasswordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            try
            {

                if (user != null && PasswordCheck != false)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { code = 200, token = token });
                }
                else
                {
                    var ErrorMessage = "";

                    if(user == null)
                    {
                        ErrorMessage = "unable to Find User";
                    }
                    if (PasswordCheck == false)
                    {
                        ErrorMessage = "unable to Match User Info";
                    }
                    return Ok( new { code = 401 , message = ErrorMessage});
                }
            }
            catch (Exception ex)
            {
                return Ok( new { code = 401 , message = ex });
            }

        }
    }
}
