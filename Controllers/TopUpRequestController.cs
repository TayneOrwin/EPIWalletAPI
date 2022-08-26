
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.TopUpRequest;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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




        private readonly IConfiguration _configuration;
        private readonly ITopUpRequestRepository _topUpRequestRepository;
        private readonly AppDbContext _appDbContext = new AppDbContext();
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IExpenseRequestRepository _expenseRequestRepository;


        private readonly IEmployeeRepository _employeeRepository;
        public TopUpRequestController(IEmployeeRepository employeeRepository, ITopUpRequestRepository topUpRequestRepository, AppDbContext appDbContext, IConfiguration configuration, IApplicationUserRepository applicationUserRepository, IExpenseRequestRepository expenseRequestRepository)
        {
            _topUpRequestRepository = topUpRequestRepository;
            _appDbContext = appDbContext;
            _configuration = configuration;
            _employeeRepository = employeeRepository;
            _applicationUserRepository = applicationUserRepository;
            _expenseRequestRepository = expenseRequestRepository;

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






        [HttpGet]
        [Route("GetAllPending")]
        public async Task<ActionResult> GetPendingRequestsAsync()
        {
            try
            {
                var results = await _topUpRequestRepository.getPendingRequestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }





        [HttpGet]
        [Route("GetAllApproved")]
        public async Task<ActionResult> GetApprovedRequestsAsync()
        {
            try
            {
                var results = await _topUpRequestRepository.getApprovedRequestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }




        [HttpGet]
        [Route("GetAllPaid")]
        public async Task<ActionResult> GetPaidRequestsAsync()
        {
            try
            {
                var results = await _topUpRequestRepository.getPaidRequestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }














        [HttpGet]
        [Route("GetUserPaid")]
        public object getUserPaidRequestsAsync(int id)
        {
         
            var list = new List<TopUpRequestReturnModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "Select TopUpRequestID, topUpRequests.expenseLineID,Reason,Amount from topUpRequests INNER JOIN expenseLines on topUpRequests.expenseLineID = expenseLines.expenseLineID INNER JOIN expenseRequests on ExpenseRequests.expenseID = expenseLines.expenseRequestID WHERE employeeID = " + id + " AND topUpRequests.ApprovalStatusID = 3";


            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new TopUpRequestReturnModel()
                {
                    reason = (string)reader["Reason"],
                    amount = (double)reader["Amount"],
                    TopUpRequestID = (int)reader["TopUpRequestID"],
                    ExpenseLineID = (int)reader["ExpenseLineID"],
                 
                };

                list.Add(report);
            }

            return list;

        }











        [HttpGet]
        [Route("GetUserPending")]
        public object getUserPendingRequestsAsync(int id)
        {
            var list = new List<TopUpRequestReturnModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "Select TopUpRequestID, topUpRequests.expenseLineID,Reason,Amount from topUpRequests INNER JOIN expenseLines on topUpRequests.expenseLineID = expenseLines.expenseLineID INNER JOIN expenseRequests on ExpenseRequests.expenseID = expenseLines.expenseRequestID WHERE employeeID = " + id + " AND topUpRequests.ApprovalStatusID = 1";


            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new TopUpRequestReturnModel()
                {
                    reason = (string)reader["Reason"],
                    amount = (double)reader["Amount"],
                    TopUpRequestID = (int)reader["TopUpRequestID"],
                    ExpenseLineID = (int)reader["ExpenseLineID"],

                };

                list.Add(report);
            }

            return list;


        }







        [HttpGet]
        [Route("GetUserApproved")]
        public object getUserApprovedRequestsAsync(int id)
        {
            var list = new List<TopUpRequestReturnModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "Select TopUpRequestID, topUpRequests.expenseLineID,Reason,Amount from topUpRequests INNER JOIN expenseLines on topUpRequests.expenseLineID = expenseLines.expenseLineID INNER JOIN expenseRequests on ExpenseRequests.expenseID = expenseLines.expenseRequestID WHERE employeeID = " + id + " AND topUpRequests.ApprovalStatusID = 2";


            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new TopUpRequestReturnModel()
                {
                    reason = (string)reader["Reason"],
                    amount = (double)reader["Amount"],
                    TopUpRequestID = (int)reader["TopUpRequestID"],
                    ExpenseLineID = (int)reader["ExpenseLineID"],

                };

                list.Add(report);
            }

            return list;



        }












        [HttpGet]
        [Route("GetUserRejected")]
        public object getUserRejectedRequestsAsync(int id)
        {
            var list = new List<TopUpRequestReturnModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "Select TopUpRequestID, topUpRequests.expenseLineID,Reason,Amount from topUpRequests INNER JOIN expenseLines on topUpRequests.expenseLineID = expenseLines.expenseLineID INNER JOIN expenseRequests on ExpenseRequests.expenseID = expenseLines.expenseRequestID WHERE employeeID = " + id + " AND topUpRequests.ApprovalStatusID =4";


            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new TopUpRequestReturnModel()
                {
                    reason = (string)reader["Reason"],
                    amount = (double)reader["Amount"],
                    TopUpRequestID = (int)reader["TopUpRequestID"],
                    ExpenseLineID = (int)reader["ExpenseLineID"],

                };

                list.Add(report);
            }

            return list;



        }











        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult> Approve(int id, TopUpRequestViewModel evm)
        {
            //step 1: set the status of the expense to approved

            try
            {
                var existingTopUp = await _topUpRequestRepository.getTopUpRequestAsync(id);

                if (existingTopUp == null) return NotFound("Could not find expense request with id: " + id);




               existingTopUp.ApprovalStatusID = 2;



                if (await _topUpRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }






            //step 2: send an email to all creditors notfying them that funds are requested

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";



           

            const string subject = "New Top Up Request Requiring Funds!";
            string body = "Please read the following information about the Top Up Request: \n \n" +
           "Expense Line ID: "
            + evm.ExpenseLineID + "\n \n"
             + "Amount Requested: "
                + evm.amount + "\n \n"
                  + "Reason: "
                + evm.reason + "\n \n"
            + "Please open the app to mark funds as loaded! \n" + "Kind Regards \n" + "The EPI Team";



            //Send to All Creditors
            var creditors = await _applicationUserRepository.getAllCreditors();


            for (int i = 0; i < creditors.Length; i++)
            {
                var toAddress = new MailAddress(creditors[i].Email, "Top Up Request Requiring Funds");


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

            }







            //get the employee that made that request and send him an email 
            ExpenseLine[] expenseLine = await _expenseRequestRepository.getExpenseLineByTopUp(evm.ExpenseLineID);
            int expenseRequestID = expenseLine[0].ExpenseRequestID;
            //get the request
            ExpenseRequest request = await _expenseRequestRepository.getExpenseRequestAsync(expenseRequestID);


            //step 3: Notify the employee that request has been paid
            string email = await _applicationUserRepository.getEmailByID(request.EmployeeID);
            const string subject1 = "Top Up Request Approved!";
            string body1 = "Please read the following information about the Top Up Request: \n \n" + "Amount Requested: R"
            + evm.amount + "\n \n"
             + "Reason: "
                + evm.reason + "\n \n" +

            "The Top Up Request has been sent to Creditors! \n" + "Kind Regards \n" + "The EPI Team";
            var toAddress1 = new MailAddress(email, "Top Up Request Approved!");


            var smtp1 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress1)
            {
                Subject = subject1,
                Body = body1
            })
            {
                smtp1.Send(message);




                return Ok("success");

            }
        }








        [HttpPost]
        [Route("Reject")]
        public async Task<ActionResult> Reject(int id, TopUpRequestViewModel evm, string reason)
        {
            try
            {
                var existingTopUp = await _topUpRequestRepository.getTopUpRequestAsync(id);

                if (existingTopUp == null) return NotFound("Could not find expense request with id: " + id);




                existingTopUp.ApprovalStatusID = 4;



                if (await _topUpRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }







            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";

            //get the employee that made that request that it was rejected 
            ExpenseLine[] expenseLine = await _expenseRequestRepository.getExpenseLineByTopUp(evm.ExpenseLineID);
            int expenseRequestID = expenseLine[0].ExpenseRequestID;
            //get the request
            ExpenseRequest request = await _expenseRequestRepository.getExpenseRequestAsync(expenseRequestID);


            //step 3: Notify the employee that request has been paid
            string email = await _applicationUserRepository.getEmailByID(request.EmployeeID);
            const string subject1 = "Top Up Request Rejected!";
            string body1 = "Please read the following information about the Top Up Request: \n \n" + "Amount Requested: R"
            + evm.amount + "\n \n"
             + "Reason: "
                + evm.reason + "\n \n" +
                "Reason For Rejection: "
                + reason + "\n \n" +

            "Please Resubmit the request! \n" + "Kind Regards \n" + "The EPI Team";
            var toAddress1 = new MailAddress(email, "Top Up Request Rejected!");


            var smtp1 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress1)
            {
                Subject = subject1,
                Body = body1
            })
            {
                smtp1.Send(message);




                return Ok("success");

            }
















        }












        [HttpPost]
        [Route("MarkAsPaid")]
        public async Task<ActionResult> MarkAsPaid(int id, TopUpRequestViewModel evm)
        {
            //step 1: set the status of the expense to paid and set approval to paid



            try
            {
                var existingTopUpRequest = await _topUpRequestRepository.getTopUpRequestAsync(id);

                if (existingTopUpRequest == null) return NotFound("Could not find expense request with id: " + id);




                existingTopUpRequest.ApprovalStatusID = 3;
               



                if (await _topUpRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }


            const string fromPassword = "vokbgidjiuxonyfl";

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");



            //get the employee that made that request and send him an email 
            ExpenseLine[] expenseLine = await _expenseRequestRepository.getExpenseLineByTopUp(evm.ExpenseLineID);
            int expenseRequestID = expenseLine[0].ExpenseRequestID;
            //get the request
            ExpenseRequest request = await _expenseRequestRepository.getExpenseRequestAsync(expenseRequestID);
         

            //step 3: Notify the employee that request has been paid
            string email = await _applicationUserRepository.getEmailByID(request.EmployeeID);
            const string subject1 = "Top Up Request Paid!";
            string body1 = "Please read the following information about the Top Up Request: \n \n" +  "Amount Requested: R"
            + evm.amount + "\n \n"
             + "Reason: "
                + evm.reason + "\n \n"+
             
            "Funds for the top up have now been loaded by the creditor! \n" + "Kind Regards \n" + "The EPI Team";
            var toAddress1 = new MailAddress(email, "Expense Request Paid!");


            var smtp1 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress1)
            {
                Subject = subject1,
                Body = body1
            })
            {
                smtp1.Send(message);




                return Ok("success");

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
        public async Task<ActionResult> SendForApproval(TopUpRequestViewModel evm,string email)
        {

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
      
            const string fromPassword = "vokbgidjiuxonyfl";


            const string subject = "Top Up Request!";
            string body = "Please read the following information about the TopUp: \n \n" + "Request from : "
            + email + "\n \n" + "Expense Line ID : "
            + evm.ExpenseLineID + "\n \n" + "Top Up Amount: "
            + evm.amount + "\n \n"
             + "Reason: "
                + evm.reason + "\n \n"
            + "Please open the app to approve or reject the request! \n" + "Kind Regards \n" + "The EPI Team";

            //Send to All Managers
            var managers = await _applicationUserRepository.getAllManagers();


            for (int i = 0; i < managers.Length; i++)
            {
                var toAddress = new MailAddress(managers[i].Email, "Top Up Request");


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

            }
            return Ok("Success");



















        }


        [HttpGet]
        [Route("GetExpenseRequestForTopUpRequest")]

        public object GetExpenseRequestForTopUpRequest()
        {
            var list = new List<TopUpRequestReport>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "select ExpenseRequests.EmployeeID, topUpRequests.TopUpRequestID, topUpRequests.Amount, expenseLines.ExpenseLineID, ExpenseRequests.ExpenseID, ExpenseRequests.totalEstimate, (topUpRequests.Amount/ExpenseRequests.totalEstimate * 100) As Percentage from topUpRequests inner join expenseLines on topUpRequests.ExpenseLineID = expenseLines.ExpenseLineID inner join ExpenseRequests on expenseLines.ExpenseRequestID = ExpenseRequests.ExpenseID";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new TopUpRequestReport()
                {
                    EmployeeID = (int)reader["EmployeeID"],
                    percentage = (double)reader["Percentage"],
                    amount = (double)reader["Amount"],
                    TopUpRequestID = (int)reader["TopUpRequestID"],
                    ExpenseLineID = (int)reader["ExpenseLineID"],
                    ExpenseRequestID = (int)reader["ExpenseID"],
                    TotalEstimate = (double)reader["totalEstimate"]
                };

                list.Add(report);
            }

            return list;

        }

    }
}
