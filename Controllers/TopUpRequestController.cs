using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopUpRequestController : ControllerBase
    {
      



            
        private readonly ITopUpRequestRepository _topUpRequestRepository;
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public TopUpRequestController(ITopUpRequestRepository topUpRequestRepository, AppDbContext appDbContext)
        {
            _topUpRequestRepository = topUpRequestRepository;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("GetAllRequests")]

        public async Task<ActionResult> GetAllRequestsAsync()
        {


            try
            {
                var results = await _topUpRequestRepository.getAllTopUpRequestsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

 


        [HttpPost]
        [Route("AddRequest")]

        public async Task<ActionResult> AddRequest(TopUpRequestViewModel evm)
        {

            var request = new TopUpRequest { ExpenseLineID = evm.ExpenseLineID, ApprovalStatusID = 1, Amount=evm.amount,Reason=evm.reason };

            try
            {
                _topUpRequestRepository.Add(request);
                await _topUpRequestRepository.SaveChangesAsync();

            }
            catch (Exception err)
            {
                return Ok(err); ;
            }

            return Ok("Success");
        }


        [HttpPost]
        [Route("SendForApproval")]
        public async Task<ActionResult> SendForApproval(TopUpRequestViewModel evm)
        {


            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
            var toAddress = new MailAddress("tayne.orwin@gmail.com", "Top Up Request");
            const string fromPassword = "vokbgidjiuxonyfl";



            const string subject = "Top Up Request!";
            string body = "Please read the following information about the TopUp: \n \n" + "Request from : "
            + evm.user + "\n \n" + "Expense Line ID : "
            + evm.ExpenseLineID + "\n \n" + "Top Up Amount: "
            + evm.amount + "\n \n"
             + "Reason: "
                + evm.reason + "\n \n"
            + "Please open the app to respond to request! \n" + "Kind Regards \n" + "The EPI Team";

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


        [HttpGet]
        [Route("GetExpenseRequestForTopUpRequest")]

        public object GetExpenseRequestForTopUpRequest()
        {

            var result = (from topup in _appDbContext.topUpRequests.ToList()
                          join line in _appDbContext.expenseLines.ToList()
                          on topup.ExpenseLineID equals line.ExpenseLineID
                          join request in _appDbContext.ExpenseRequests.ToList()
                          on line.ExpenseRequestID equals request.ExpenseID
                         // group topup by topup.TopUpRequestID);
            select new ExpenseItem
            {
                itemName = _appDbContext.ExpenseItems.Select(x => x.itemName).FirstOrDefault()
            }).ToList();

            return Ok(result);
        }

    }
}
