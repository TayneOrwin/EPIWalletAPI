using System;
using Microsoft.AspNetCore.Mvc;
using EPIWalletAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EPIWalletAPI.ViewModels;

namespace EPIWalletAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseValueController : ControllerBase
    {
        private readonly IExpenseValueRepository _expenseValueRepository;



        public ExpenseValueController(IExpenseValueRepository expenseValueRepository)
        {
            _expenseValueRepository = expenseValueRepository;

        }





        [HttpGet]
        [Route("GetValue")]
        public async Task<ActionResult> GetValueAsync()
        {
            try
            {
                var results = await _expenseValueRepository.getValue(1);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }









        [HttpPut]
        [Route("UpdateValue")]

        public async Task<ActionResult> UpdateValue(ExpenseValueViewModel model)
        {



            try
            {
                var existingTimer = await _expenseValueRepository.getValue(1);

                if (existingTimer == null) return NotFound("Could not find timer");

                existingTimer.value = model.value;


                if (await _expenseValueRepository.SaveChangesAsync())
                {
                    return Ok("Value updated successfully");
                }


            }



            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }











    }





}

