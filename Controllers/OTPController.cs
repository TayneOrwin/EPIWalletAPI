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


namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {







        [HttpPost]
        [Route("SendEmail")]
        public int sendEmail(toEmail toEmail)
        {

            var fromAddress = new MailAddress("tayne.orwin@gmail.com", "System");
            var toAddress = new MailAddress(toEmail.address, "User");
            const string fromPassword = "wxifdmferszbrjjj";


            //generate a new random OTP between 1-10000
            Random rnd = new Random();
            int otp = rnd.Next(1, 10000);



            const string subject = "Requested OTP";
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


