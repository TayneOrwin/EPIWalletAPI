using EPIWalletAPI.Models.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using EPIWalletAPI.Models;
using Microsoft.AspNetCore.Identity;
using EPIWalletAPI.Migrations;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IActiveLoginRepository _activeloginRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private UserManager<ApplicationUser> _userManager;

        public EmailController(IActiveLoginRepository activeLoginRepository, IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager)
        {
            _activeloginRepository = activeLoginRepository;
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }





        [HttpPost]
        [Route("SendOTPEmail")]
        public async Task<int> sendEmailAsync(toEmail toEmail)
        {
            

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
            var toAddress = new MailAddress(toEmail.address, "EPI Login");
            const string fromPassword = "vokbgidjiuxonyfl";

            //var activeLogin = new ActiveLogin { date = DateTime.Now, ApplicationUserID = toEmail.id};

           // _activeloginRepository.Add(activeLogin);
            //await _activeloginRepository.SaveChangesAsync();

            //generate a new random OTP between 1-10000
            Random rnd = new Random();
            int otp = rnd.Next(1000, 10000);



            const string subject = "EPI Wallet Requested OTP";
            string body = "Your OTP is \n" + otp.ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                
            }



            //return that OTP to the backend
            return otp;
            

        }










    }
}


