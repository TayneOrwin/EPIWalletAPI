using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        //Add These
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicatonSettings _appSettings;
        private readonly IApplicationUserRepository _applicationuserRepository;
        private readonly IActiveLoginRepository _activeloginRepository;
      

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            IOptions<ApplicatonSettings> appSettings,
            IApplicationUserRepository applicationuserRepository,
            IActiveLoginRepository activeLoginRepository)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            _applicationuserRepository = applicationuserRepository;
            _activeloginRepository = activeLoginRepository;
            
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
                    AccessRoleID= model.accessRole,
                    EmployeeID = model.employeeID

                };

                try
                {
                    var result = await _userManager.CreateAsync(applicationUser, model.Password);
                    if (result.Succeeded)
                    {
                    

                        if (applicationUser.AccessRoleID==1)
                        {
                            return Ok(new { code = 201, message = "Employee Registered Succesfully" });
                        }


                        if (applicationUser.AccessRoleID == 2)
                        {
                            return Ok(new { code = 201, message = "Manager Registered Succesfully" });
                        }

                        if (applicationUser.AccessRoleID == 3)
                        {
                            return Ok(new { code = 201, message = "Creditor Registered Succesfully" });
                        }
                        if (applicationUser.AccessRoleID == 4)
                        {
                            return Ok(new { code = 201, message = "Administrator Registered Succesfully" });
                        }


                        else
                        {
                            return Ok(new { code = 404, message = "Register was succesful, Role Not Assigned" });
                        }






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

          
            if (PasswordCheck != false)
            {
                var appUser = await _applicationuserRepository.getUserAsync(user.Email);

                var activeLogin = new ActiveLogin { date = DateTime.Now, ApplicationUserID = appUser.Id };


                _activeloginRepository.Add(activeLogin);
                await _activeloginRepository.SaveChangesAsync();
            }

            
            
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

                    

                    if (user.AccessRoleID == 1)
                    {
                        return Ok(new { code = 200, token = token,message="Employee Access Granted" });

                    }


                    if (user.AccessRoleID == 2)
                    {
                        return Ok(new { code = 201, token = token, message="Manager Access Granted" });
                    }

                    if (user.AccessRoleID == 3)
                    {
                        return Ok(new { code = 202, token = token, message = "Creditor Access Granted" });
                    }

                    if (user.AccessRoleID == 4)
                    {
                        return Ok(new { code = 203, token = token, message = "Admin Access Granted" });
                    }


                    else
                    {
                        return Ok(new { code = 204, token = token, message = "Permission Level Not Asssigned" });
                    }






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

        [HttpGet]
        [Route("GetEmployeeId")]
        public async Task<IActionResult> GetEmployeeId(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var results = user.EmployeeID;

            return Ok(results);
        }



        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword(ApplicationUserViewModel avm)
        {

            var User = await _userManager.FindByEmailAsync(avm.UserName);
            var PasswordCheck = await _userManager.CheckPasswordAsync(User, avm.CurrentPassword);


            try
            {


                if (PasswordCheck != false && User != null)
                {
                    await _userManager.ChangePasswordAsync(User, avm.CurrentPassword, avm.NewPassword);
                    return Ok(new { code = 200, message = "Password Updated Successfully" });
                }
                else 
                {
                    var ErrorMessage = "";

                    if (User == null)
                    {
                        ErrorMessage = "unable to Find User";
                    }
                    if (PasswordCheck == false)
                    {
                        ErrorMessage = "Password Incorrect";
                    }
                    return Ok(new { code = 401, message = ErrorMessage });
                }
            }

            

            catch (Exception)
            {
                return BadRequest("Error");
            }



        }


        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ApplicationUserViewModel avm)
        {

            var User = await _userManager.FindByEmailAsync(avm.UserName);


            
                try
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);
                    var passwordReset = Url.Action("ResetPassword", "Account", new { email = avm.UserName, token = token }, Request.Scheme);
                    //await _userManager.ResetPasswordAsync(User, token, avm.NewPassword);
                     
                    return Ok(new {code = 200, message = "Password Reset Successfully" });
                }
                catch
                {
                    return BadRequest("Unsuccessful");
                }
                
                
           

        }

        

 }
}
