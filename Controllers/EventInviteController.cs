using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EPIWalletAPI.Models.Email;
using System.Net;
using System.Net.Mail;
using EPIWalletAPI.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.EventInvite;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInviteController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        
       
       
        public EventInviteController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        



        [HttpPost]
        [Route("SendInvite")]

        public async Task<ActionResult> SendInvite(EventInviteViewModel evm)
        {
            

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
            var toAddress = new MailAddress(evm.address, "Invite");
            const string fromPassword = "vokbgidjiuxonyfl";

            
                var existingEvent = await _eventRepository.getEventAsync(evm.name);



                const string subject = "You've been invited!";
                string body = "Please read the following information about the event: \n \n" + "The name of the event : " 
                + existingEvent.name + "\n \n" + "A short description of the event : " 
                + existingEvent.description + "\n \n" + "This event will take place on the following data and time : " 
                + existingEvent.date.ToString() + "\n \n"  
                + "We hope to see you there! \n" + "Kind Regards \n" + "The EPI Team";
            
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


                return Ok("success");


            }
        }


    }
}
