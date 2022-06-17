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
    public class ExpenseTypeController : ControllerBase
    {
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        //return data from the database

        //dependency injection
        public ExpenseTypeController(IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseTypeRepository = expenseTypeRepository;
        }


        [HttpGet]
        [Route("GetAllExpenseTypes")]
        public async Task<ActionResult> GetAllEventsAsync()
        {
            try
            {
                var results = await _expenseTypeRepository.getAllExpenseTypesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddExpenseType")]
        public async Task<IActionResult> AddEvent(ExpenseTypeViewModel etvm)
        {

            var type = new ExpenseType { Type = etvm.Type, EventID = etvm.EventID };

            try
            {
                _expenseTypeRepository.Add(type);
                await _expenseTypeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }


        [HttpPut]
        [Route("UpdateExpenseType")]

        public async Task<ActionResult> UpdateExpenseType(string name, ExpenseTypeViewModel etvm)
        {



            try
            {
                var existingEvent = await _expenseTypeRepository.getExpenseType(name);

                if (existingEvent == null) return NotFound("Could not find event: " + name);

                existingEvent.EventID = etvm.EventID;
                existingEvent.Type = etvm.Type;


                if (await _expenseTypeRepository.SaveChangesAsync())
                {
                    return Ok("event updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");

        }

        [HttpDelete]
        [Route("DeleteExpenseType")]
        public async Task<IActionResult> DeleteExpenseType(string name)
        {
            try
            {
                var existingEvent = await _expenseTypeRepository.getExpenseType(name);
                if (existingEvent == null) return NotFound();


                _expenseTypeRepository.Delete(existingEvent);

                if (await _expenseTypeRepository.SaveChangesAsync())
                {
                    return Ok("event deleted successfully");
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
