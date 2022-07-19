using EPIWalletAPI.Models;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository repository;
        private readonly IUserClaimsPrincipalFactory<AppUser> _claimsPrincipalFactory;
        private static Dictionary<string, TwoFactorCode> _twoFactorCodeDictionary
            = new Dictionary<string, TwoFactorCode>();

        public AuthenticationController(UserManager<AppUser> userManager, IUserClaimsPrincipalFactory<AppUser> claimsPrincipalFactory)
        {
            _userManager = userManager;
            _claimsPrincipalFactory = claimsPrincipalFactory;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.PasswordHash))
                {
                    try
                    {
                        var principal = await _claimsPrincipalFactory.CreateAsync(user);
                        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

                        // Otp 
                        var otp = GenerateTwoFactorCodeFor(user.UserName);

                        var fromEmailAddress = "youremailaddresstosendtheemail"; 
                        var subject = "System Log in";
                        var message = $"Enter the following OTP: {otp}";
                        var toEmailAddress = user.Email;

                        // Sending email
                        await SendEmail(fromEmailAddress, subject, message, toEmailAddress);
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid user credentials.");
                }
            }

            var loggedInUser = new UserViewModel { UserName = model.UserName };

            return Ok(loggedInUser);
        }

        

        [HttpPost]
        [Route("Otp")]
        public IActionResult VerifyOTP(UserViewModel user)
        {
            var validOtp = VerifyTwoFactorCodeFor(user.UserName, user.otp);

            if (validOtp)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Invalid OTP");
        }

        private async Task SendEmail(string fromEmailAddress, string subject, string message, string toEmailAddress)
        {
            var fromAddress = new MailAddress(fromEmailAddress);
            var toAddress = new MailAddress(toEmailAddress);

            using (var compiledMessage = new MailMessage(fromAddress, toAddress))
            {
                compiledMessage.Subject = subject;
                compiledMessage.Body = string.Format("Message: {0}", message);

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "yourownprovidedhost"; 
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("theemailaccountthatyouwillbeusing", "theemailaccountspassword"); 
                    await smtp.SendMailAsync(compiledMessage);
                }
            }
        }

        private static string GetUniqueKey()
        {
            Random rnd = new Random();

            var optCode = rnd.Next(1000, 9999);

            return optCode.ToString();
        }

        private static string GenerateTwoFactorCodeFor(string username)
        {
            var code = GetUniqueKey();

            var twoFactorCode = new TwoFactorCode(code);

            
            _twoFactorCodeDictionary[username] = twoFactorCode;

            return code;
        }

        private bool VerifyTwoFactorCodeFor(string subject, string code)
        {
            TwoFactorCode twoFactorCodeFromDictionary = null;
            
            if (_twoFactorCodeDictionary
                .TryGetValue(subject, out twoFactorCodeFromDictionary))
            {
                if (twoFactorCodeFromDictionary.CanBeVerifiedUntil > DateTime.Now
                    && twoFactorCodeFromDictionary.Code == code)
                {
                    twoFactorCodeFromDictionary.IsVerified = true;
                    return true;
                }
            }
            return false;
        }
    }
}
