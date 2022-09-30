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
    public class AdminTimerController : ControllerBase
    {
        private readonly IAdminTimerRepository _adminTimerRepository;



        public AdminTimerController(IAdminTimerRepository adminTimerRepository)
        {
            _adminTimerRepository = adminTimerRepository;

        }





        [HttpGet]
        [Route("GetTimer")]
        public async Task<ActionResult> GetTimerAsync()
        {
            try
            {
                var results = await _adminTimerRepository.getTimer(1);
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }









        [HttpPut]
        [Route("UpdateTimer")]

        public async Task<ActionResult> UpdateTimer(AdminTimerViewModel model)
        {



            try
            {
                var existingTimer = await _adminTimerRepository.getTimer(1);

                if (existingTimer == null) return NotFound("Could not find timer");

               existingTimer.value= model.value;


                if (await _adminTimerRepository.SaveChangesAsync())
                {
                    return Ok("Timer updated successfully");
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

