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
    public class ExpenseLineController : ControllerBase
    {
        private readonly IExpenseLineRepository _expenseLineRepository;
        //return data from the database

        //dependency injection
        public ExpenseLineController(IExpenseLineRepository expenseLineRepository)
        {
            _expenseLineRepository = expenseLineRepository;
        }


        [HttpGet]
        [Route("GetAllExpenseLines")]
        public async Task<ActionResult> GetAllExpenseLinesAsync()
        {
            try
            {
                var results = await _expenseLineRepository.getAllExpenseLinesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }



        [HttpPost]
        [Route("AddExpenseLine")]

        public async Task<ActionResult> AddExpenseLine(ExpenseLineViewModel evm)
        {

            var expenseLine = new ExpenseLine { ExpenseRequestID = evm.ExpenseRequestID };

            try
            {
                _expenseLineRepository.Add(expenseLine);
                await _expenseLineRepository.SaveChangesAsync();

            }
            catch (Exception err)
            {
                return Ok(err); ;
            }

            return Ok("Success");
        }



        [HttpGet]
        [Route("GetExpenseLineByRequestId")]

        public async Task<IActionResult> GetExpenseLineByRequestId(int id)
        {

            var results = await _expenseLineRepository.getExpenseLineByExpenseRequest(id);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }



        [HttpDelete]
        [Route("DeleteExpenseLine")]
        public async Task<IActionResult> DeleteExpenseLine(int id)
        {
            try
            {
                var existingExpenseLine = await _expenseLineRepository.getExpenseLineAsync(id);
                if (existingExpenseLine == null) return NotFound();


                _expenseLineRepository.Delete(existingExpenseLine);

                if (await _expenseLineRepository.SaveChangesAsync())

                {
                    return Ok("expenseLine deleted successfully");
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
