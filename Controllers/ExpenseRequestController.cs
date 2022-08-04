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
        [Route("GetAllExpenseRequests")]
        public async Task<ActionResult> GetAllExpenseRequestsAsync()
        {
            try
            {
                var results = await _ExpenseRequestRepository.getAllExpenseRequestsAsync();
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

            var TexpenseRequest = new ExpenseRequest { TypeID = , EmployeeID = evm.EmployeeID, ApprovalID = evm.ApprovalID, totalEstimate=evm.TotalEstimate  };

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






















    }
}
