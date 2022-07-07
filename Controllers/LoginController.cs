using EPIWalletAPI.Models;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly UserManager<AppUser> userManager;
        private readonly IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory;
        private UserManager<AppUser> _userManager;
        private IUserClaimsPrincipalFactory<AppUser> _claimsPrincipalFactory;

        public LoginController(UserManager<AppUser> userManager
            , IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _claimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        [HttpPost]
        [Route("Login")]
         public async Task<IActionResult> Login(UserViewModel uvm)
        {

            var user = await _userManager.FindByNameAsync(uvm.EmailAddress);

            if (user != null && await _userManager.CheckPasswordAsync(user, uvm.Password))
            {
                try
                {
                    var principal = await _claimsPrincipalFactory.CreateAsync(user);
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);
                }
                catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
                }
            }
            return Ok();
        }
    }
}
