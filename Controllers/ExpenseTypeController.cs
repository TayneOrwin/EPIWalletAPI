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
        private readonly IEventRepository _eventRepository;
        //return data from the database

        //dependency injection
        public ExpenseTypeController(IExpenseTypeRepository expenseTypeRepository, IEventRepository eventRepository)
        {
            _expenseTypeRepository = expenseTypeRepository;
            _eventRepository = eventRepository; 
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
        public async Task<object> AddEvent(ExpenseTypeViewModel etvm)
        {

            var type = new ExpenseType { Type = etvm.Type };

            try
            {
                _expenseTypeRepository.Add(type);
                await _expenseTypeRepository.SaveChangesAsync();
            }


        

            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });



        }


        [HttpPut]
        [Route("UpdateExpenseType")]

        public async Task<object> UpdateExpenseType(string name, ExpenseTypeViewModel etvm)
        {



            try
            {
                var existingEvent = await _expenseTypeRepository.getExpenseType(name);

                if (existingEvent == null) return NotFound("Could not find event: " + name);

                existingEvent.Type = etvm.Type;


                if (await _expenseTypeRepository.SaveChangesAsync())
                {
                    return Ok("expense type updated successfully");
                }


            }



            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


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
                    return Ok("expense type updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchExpenseTypes")]

        public async Task<ActionResult<IEnumerable<ExpenseType>>> Search(string name)
        {
            try
            {
                var results = await _expenseTypeRepository.Search(name);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Expense Type");
            }

            catch(Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }


    }
}
