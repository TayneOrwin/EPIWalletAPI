using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class ExpenseRequestController : ControllerBase
    {
        private readonly IExpenseRequestRepository _ExpenseRequestRepository;

        public ExpenseRequestController(IExpenseRequestRepository expenserequestRepository)
        {
            _ExpenseRequestRepository = expenserequestRepository;
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
        [Route("GetPaidExpenseRequests")]
        public async Task<ActionResult> GetPaidExpenseRequestsAsync()
        {
            try
            {
                var results = await _ExpenseRequestRepository.getPaidExpenseRequestsAsync();
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
        [Route("UpdateEvent")]

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

























    }
}
