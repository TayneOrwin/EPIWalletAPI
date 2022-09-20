using EPIWalletAPI.Models;
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
using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Vendor;
using Microsoft.Extensions.Configuration;
//using EPIWalletAPI.Models.ExpenseRequest;
using Microsoft.Data.SqlClient;
using EPIWalletAPI.Models.ExpenseType;
using EPIWalletAPI.Models.Identity;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class ExpenseRequestController : ControllerBase
    {
        private readonly IExpenseRequestRepository _ExpenseRequestRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IEmployeeBankingDetailsRepository _bankingDetailsRepository;
        private readonly IEventRepository _eventRepository;
        public ExpenseRequestController(IExpenseRequestRepository expenserequestRepository, IEmployeeRepository employeeRepository, IVendorRepository vendorRepository, IExpenseTypeRepository expenseTypeRepository,IEmployeeBankingDetailsRepository employeeBankingDetailsRepository,IEventRepository eventRepository,
            IConfiguration configuration, IApplicationUserRepository applicationUserRepository)
        {
            _ExpenseRequestRepository = expenserequestRepository;
            _employeeRepository = employeeRepository;
            _vendorRepository = vendorRepository;
            _expenseTypeRepository = expenseTypeRepository;
            _configuration = configuration;
            _applicationUserRepository = applicationUserRepository;
            _bankingDetailsRepository = employeeBankingDetailsRepository;
            _eventRepository = eventRepository;

        }


        [HttpGet]
        [Route("GetPendingExpenseRequests")]
        public async Task<ActionResult> GetPendingExpenseRequestsAsync()
        {
            try
            {
                var results = await _ExpenseRequestRepository.getPendingExpenseRequestsAsync();
                return Ok(results);
            }



            
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }



        [HttpGet]
        [Route("GetItemsByID")]
        public async Task<ActionResult> GetItemsByID(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.GetExpenseItemsByID(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }
        }




        [HttpGet]
        [Route("GetUserPendingExpenseRequests")]
        public async Task<ActionResult> GetUserPendingExpenseRequestsAsync(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getUserPendingExpenseRequestsAsync(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }



















        [HttpGet]
        [Route("GetApprovedExpenseRequests")]
        public async Task<ActionResult> GetApprovedExpenseRequestsAsync()
        {
            try
            {
                var results = await _ExpenseRequestRepository.getApprovedExpenseRequestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }



        [HttpGet]
        [Route("GetUserApprovedExpenseRequests")]
        public async Task<ActionResult> GetUserApprovedExpenseRequestsAsync(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getUserApprovedExpenseRequestsAsync(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpGet]
        [Route("GetUserRejectedExpenseRequests")]
        public async Task<ActionResult> GetUserRejectedExpenseRequestsAsync(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getUserRejectedExpenseRequestsAsync(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


















        [HttpGet]
        [Route("GetPaidExpenseRequests")]
        public async Task<ActionResult> GetPaidExpenseRequestsAsync(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getUserPaidExpenseRequestsAsync(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }







        [HttpGet]
        [Route("GetAllPaidExpenseRequests")]
        public async Task<ActionResult> GetAllPaidExpenseRequestsAsync()
        {
            try
            {
                var results = await _ExpenseRequestRepository.getAllPaidExpenseRequestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }















        [HttpPost]
        [Route("AddExpenseRequest")]
        public async Task<IActionResult> AddExpenseRequest(ExpenseRequestViewModel evm)
        {

            var TexpenseRequest = new ExpenseRequest { TypeID =evm.TypeID ,VendorID=evm.VendorID, EmployeeID = evm.EmployeeID, ApprovalID = evm.ApprovalID, totalEstimate=evm.TotalEstimate , PaymentStatusID=evm.PaymentStatusID};

            try
            {
                _ExpenseRequestRepository.Add(TexpenseRequest);
                await _ExpenseRequestRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }


        [HttpPut]
        [Route("UpdateExpenseRequest")]

        public async Task<ActionResult> UpdateExpenseRequest(int id, ExpenseRequestViewModel evm)
        {



            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);

                if (existingExpenseRequest == null) return NotFound("Could not find expense request with id: " + id);

                existingExpenseRequest.TypeID = evm.TypeID;
                existingExpenseRequest.VendorID = evm.VendorID;
                existingExpenseRequest.EmployeeID = evm.EmployeeID;
                existingExpenseRequest.ApprovalID = evm.ApprovalID;
                existingExpenseRequest.totalEstimate = evm.TotalEstimate;
                existingExpenseRequest.PaymentStatusID = evm.PaymentStatusID;



                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {
                    return Ok("Expense Request updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }


        [HttpDelete]
        [Route("DeleteExpenseRequest")]
        public async Task<IActionResult> DeleteExpenseRequest(int id)
        {
           

  


            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);
                if (existingExpenseRequest == null) return NotFound();


                _ExpenseRequestRepository.Delete(existingExpenseRequest);

                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {
                    return Ok("expense request deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }











            return Ok("success");









        }








        [HttpPost]
        [Route("CancelEmail")]
        public async Task<ActionResult> CancelEmail(ExpenseRequestViewModel evm)
        {


            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";
            var employee = await _employeeRepository.GetEmployeeByID(evm.EmployeeID);


            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);

            const string subject = "Expense Request Cancelled!";
            string body = "Please read the following information about the Cancelled Expense Request: \n \n" + "Request from Employee : "
            + employee + "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n"
            + " \n" + "Kind Regards \n" + "The EPI Team";



            //Send to All Managers
            var managers = await _applicationUserRepository.getAllManagers();


            for (int i = 0; i < managers.Length; i++)
            {
                var toAddress = new MailAddress(managers[i].Email, "Expense Request Cancelled by Employee");


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
































        [HttpPost]
        [Route("SendForApproval")]
        public async Task<ActionResult> SendForApproval(ExpenseRequestViewModel evm)
        {


            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
         
            const string fromPassword = "vokbgidjiuxonyfl";
            var employee = await _employeeRepository.GetEmployeeByID(evm.EmployeeID);
         

          
            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);
            int currentEventID = await _eventRepository.getEventIdByTypeID(evm.TypeID);
            var currentEvent = await _eventRepository.getEventByIdAsync(currentEventID);


          
            const string subject = "New Expense Request Requiring Approval!";
            string body = "Please read the following information about the Expense Request: \n \n" + "Request from Employee : "
            + employee[0] +  "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n"
                     + "Details Regarding The Event: " + "\n \n"
                          + "Event Name: "
                + currentEvent.name + "\n \n"
                     + "Event Date: "
                + currentEvent.date + "\n \n"
             + "Event Description: "
                + currentEvent.description + "\n \n"
            + "Please open the app to approve request! \n" + "Kind Regards \n" + "The EPI Team";



            //Send to All Managers
            var managers = await _applicationUserRepository.getAllManagers();


            for (int i = 0; i < managers.Length; i++)
            {
                var toAddress = new MailAddress(managers[i].Email, "Expense Request Approval");


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



            return Ok("success");





        }





        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult> Approve(int id, ExpenseRequestViewModel evm)
        {
            //step 1: set the status of the expense to approved

            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);

                if (existingExpenseRequest == null) return NotFound("Could not find expense request with id: " + id);




                existingExpenseRequest.ApprovalID = 2;



                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }






            //step 2: send an email to all creditors notfying them that funds are requested

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";
            var employee = await _employeeRepository.GetEmployeeByID(evm.EmployeeID);
            var banking = await _bankingDetailsRepository.getEmployeeBankingDetailsAsync(evm.EmployeeID);

            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);

            const string subject = "New Expense Request Requiring Funds!";
            string body = "Please read the following information about the Expense Request: \n \n" + "Submitted By : "
            + employee[0] + "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n"
                + "\n \n" +
                "Employee banking details:"
                + " \n \nAccount Number: "+
                banking.AccountNunmber
                         + " \n \nBranch: " +
                banking.Branch
                 + " \n \nBank: " +
                banking.Bank
                 + " \n \n:"
       




            + "Please open the app to mark funds as loaded! \n" + "Kind Regards \n" + "The EPI Team";



            //Send to All Creditors
            var creditors = await _applicationUserRepository.getAllCreditors();


            for (int i = 0; i < creditors.Length; i++)
            {
                var toAddress = new MailAddress(creditors[i].Email, "Expense Request Approval");


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







            //step 3: Notify the employee that expense has been approved and is now awaiting payment
            string email = await _applicationUserRepository.getEmailByID(evm.EmployeeID);
            const string subject1 = "Expense Has Been Approved!";
            string body1 = "Please read the following information about the Expense Request: \n \n" + "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n" +
                 "The Creditor Has Been Notified \n"
            + "The Expense is now awaiting funds from the creditor! \n" + "Kind Regards \n" + "The EPI Team";
            var toAddress1 = new MailAddress(email, "Expense Request Approved!");


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
        public async Task<ActionResult> Reject(int id,ExpenseRequestViewModel evm,string reason)
        {
            //step 1: set the status of the expense to rejected
            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);

                if (existingExpenseRequest == null) return NotFound("Could not find expense request with id: " + id);




                existingExpenseRequest.ApprovalID = 4;



                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }

            //step 3: Notify the employee that expense was rejected and the reason it was rejected
            //get the email associatced with the request sent through

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";
            var employee = await _employeeRepository.GetEmployeeByID(evm.EmployeeID);


            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);






            string email = await _applicationUserRepository.getEmailByID(evm.EmployeeID);
            const string subject1 = "Expense Has Been Rejected!";
            string body1 = "Please read the following information about the Expense Request: \n \n" + "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n" +
                "Reason For Rejection: " + reason+ "\n \n" +
                 "Please attempt to resubmit the expense! \n"
            + " \n" + "Kind Regards \n" + "The EPI Team";
            var toAddress1 = new MailAddress(email, "Expense Request Rejected!");


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
        public async Task<ActionResult> MarkAsPaid(int id,ExpenseRequestViewModel evm)
        {
            //step 1: set the status of the expense to paid and set approval to paid

       

            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);

                if (existingExpenseRequest == null) return NotFound("Could not find expense request with id: " + id);




                existingExpenseRequest.ApprovalID = 3;



                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }

            ///notify the employee via email that his expense has been paid
            ///    var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            const string fromPassword = "vokbgidjiuxonyfl";

            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");

            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);


            //step 3: Notify the employee that expense has been approved and is now awaiting payment
            string email = await _applicationUserRepository.getEmailByID(evm.EmployeeID);
            const string subject1 = "Expense Has Been Paid!";
            string body1 = "Please read the following information about the Expense Request: \n \n" + "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n" +
          
            "Funds for the expense have now been loaded by the creditor! \n" + "Kind Regards \n" + "The EPI Team";
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




        [HttpGet]
        [Route("SearchRequest")]
        public async Task<ActionResult<IEnumerable<ExpenseRequest>>> Search(int id,int approvalstatus,int employee) 
        {
            try
            {
                var result = await _ExpenseRequestRepository.Search(id,approvalstatus,employee);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Could not find the requested expense request");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }


        [HttpGet]
        [Route("SearchRequests")]
        public async Task<ActionResult<IEnumerable<ExpenseRequest>>> Search2(int id, int approvalstatus)
        {
            try
            {
                var result = await _ExpenseRequestRepository.Search2(id, approvalstatus);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Could not find the requested expense request");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }








        [HttpPost]
        [Route("MarkCleaned")]
        public async Task<ActionResult> MarkCleaned(int id, ExpenseRequestViewModel evm)
        {
            //step 1: set the status of the expense to paid and set approval to paid



            try
            {
                var existingExpenseRequest = await _ExpenseRequestRepository.getExpenseRequestAsync(id);

                if (existingExpenseRequest == null) return NotFound("Could not find expense request with id: " + id);




                existingExpenseRequest.PaymentStatusID = 2;


     
                if (await _ExpenseRequestRepository.SaveChangesAsync())
                {

                }


            }




            catch (Exception)
            {

            }



            return Ok("Success");


        }






























        [HttpGet]
        [Route("GetRequests")]

        public async Task<IActionResult> GetRequests()
        {
            
            try
            {
                var results = await _ExpenseRequestRepository.getAllRequests();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }
        }


        [HttpGet]
        [Route("getExpenseRequestForEmployee")]
        public async Task<IActionResult> getExpenseRequestForEmployee(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getExpenseRequestForEmployee(id);
                return Ok(results);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("ExpenseTypeReport")]

        public object ExpenseTypeReport()
        {
            var list = new List<ExpenseRequestPerTypeReport>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "select ExpenseTypes.Type, count(*) as TotalRequests from ExpenseTypes inner join ExpenseRequests on ExpenseRequests.TypeID = ExpenseTypes.TypeID Group by ExpenseTypes.Type";


            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new ExpenseRequestPerTypeReport
                {
                    Type = (string)reader["Type"],
                    Requests = (int)reader["TotalRequests"]
                };

                list.Add(report);
            }

            return list;
        }


        //for adjustable criteria

        //[HttpGet]
        //[Route("ExpenseSpecificTypeReport")]

        //public object ExpenseSpecificTypeReport(string type)
        //{
        //    var list = new List<ExpenseRequestPerTypeReport>();
        //    var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        //    var sql = "select ExpenseTypes.Type, count(*) as TotalRequests from ExpenseTypes inner join ExpenseRequests on ExpenseRequests.TypeID = ExpenseTypes.TypeID where ExpenseTypes.Type = '"+type+"' Group by ExpenseTypes.Type";
        //    connection.Open();
        //    using SqlCommand command = new SqlCommand(sql, connection);
        //    using SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var report = new ExpenseRequestPerTypeReport
        //        {
        //            Type = (string)reader["Type"],
        //            Requests = (int)reader["TotalRequests"]
        //        };

        //        list.Add(report);
        //    }

        //    return list;
        //}

        [HttpGet]
        [Route("ExpenseSpecificTypeReport")]

        public object GetOriginalAmount(string type)
        {
            var list = new List<ExpenseRequestPerTypeReport>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "select receipts.ReceiptID from receipts inner join expenseLines on expenseLines.ExpenseLineID = receipts.ExpenseLineID inner join ExpenseRequests on ExpenseRequests.ExpenseID = expenseLines.ExpenseRequestID";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var report = new ExpenseRequestPerTypeReport
                {
                    Type = (string)reader["Type"],
                    Requests = (int)reader["TotalRequests"]
                };

                list.Add(report);
            }

            return list;
        }


        


        [HttpGet]
        [Route("GetRequest")]
        public async Task<ActionResult> GetRequest(int id)
        {
            try
            {
                var results = await _ExpenseRequestRepository.getExpenseRequestAsync(id);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }








    }
}
