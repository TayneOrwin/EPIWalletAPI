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

        public ExpenseRequestController(IExpenseRequestRepository expenserequestRepository, IEmployeeRepository employeeRepository, IVendorRepository vendorRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _ExpenseRequestRepository = expenserequestRepository;
            _employeeRepository = employeeRepository;
            _vendorRepository = vendorRepository;
            _expenseTypeRepository = expenseTypeRepository;

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

            return BadRequest();
        }



        [HttpPost]
        [Route("SendForApproval")]
        public async Task<ActionResult> SendForApproval(ExpenseRequestViewModel evm)
        {


            var fromAddress = new MailAddress("epiwalletsystem@gmail.com", "EPI Wallet");
            var toAddress = new MailAddress("tayne.orwin@gmail.com", "Expense Request Approval");
            const string fromPassword = "vokbgidjiuxonyfl";
            var employee = await _employeeRepository.GetEmployeeByID(evm.EmployeeID);
            var vendor = await _vendorRepository.GetNameByID(evm.VendorID);
            var expenseType = await _expenseTypeRepository.getExpenseTypeByID(evm.TypeID);
           
            const string subject = "New Expense Request Requiring Approval!";
            string body = "Please read the following information about the Expense Request: \n \n" + "Request from Employee : "
            + employee +  "\n \n" + "Estimate of Request: R"
            + evm.TotalEstimate + "\n \n"
             + "Vendor Name: "
                + vendor + "\n \n"
                  + "Expense Type: "
                + expenseType + "\n \n"
            + "Please open the app to approve request! \n" + "Kind Regards \n" + "The EPI Team";

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


















    }
}
