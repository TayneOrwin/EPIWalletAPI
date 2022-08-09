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
    public class ExpenseItemController : ControllerBase
    {
        private readonly IExpenseItemRepository _expenseItemRepository;
        //return data from the database

        //dependency injection
        public ExpenseItemController(IExpenseItemRepository expenseItemRepository)
        {
            _expenseItemRepository = expenseItemRepository;
        }


        [HttpGet]
        [Route("GetAllExpenseItems")]
        public async Task<ActionResult> GetAllExpenseItemsAsync()
        {
            try
            {
                var results = await _expenseItemRepository.getAllExpenseItemsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddExpenseItem")]
        public async Task<IActionResult> AddExpenseItem(ExpenseItemViewModel evm)
        {

            var Tevent = new ExpenseItem { ExpenseRequestID = evm.ExpenseRequestID, itemName = evm.itemName, itemDescription = evm.itemDescription, estimateCost= evm.estimateCost,supplier=evm.supplier };

            try
            {
                _expenseItemRepository.Add(Tevent);
                await _expenseItemRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



        [HttpPut]
        [Route("UpdateExpenseItem")]

        public async Task<ActionResult> UpdateExpenseItem(string name, ExpenseItemViewModel evm)
        {



            try
            {
                var existingItem = await _expenseItemRepository.getExpenseItemAsync(name);

                if (existingItem == null) return NotFound("Could not find item: " + name);

                existingItem.ExpenseRequestID = evm.ExpenseRequestID;
                existingItem.itemName = evm.itemName;
                existingItem.itemDescription = evm.itemDescription;
                existingItem.estimateCost = evm.estimateCost;
                existingItem.supplier = evm.supplier;


                if (await _expenseItemRepository.SaveChangesAsync())
                {
                    return Ok("Item updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }





        [HttpDelete]
        [Route("DeleteExpenseItem")]
        public async Task<IActionResult> DeleteExpenseItem(string name)
        {
            try
            {
                var existingItem = await _expenseItemRepository.getExpenseItemAsync(name);
                if (existingItem == null) return NotFound();


                _expenseItemRepository.Delete(existingItem);

                if (await _expenseItemRepository.SaveChangesAsync())
                {
                    return Ok("Item deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchExpenseItem")]

        public async Task<ActionResult<IEnumerable<ExpenseItem>>> Search(string name)
        {
            try
            {
                var results = await _expenseItemRepository.Search(name);
                if (results != null)
                {
                    return Ok(results);
                }

                return NotFound("Could not find the requested Expense item in the database");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }
        }
    }
}
