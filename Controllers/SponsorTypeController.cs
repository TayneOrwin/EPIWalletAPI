using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.SponsorType;
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
    public class SponsorTypeController : ControllerBase
    {

        private readonly ISponsorTypeRepository _sponsorTypeRepository;

        public SponsorTypeController(ISponsorTypeRepository sponsorTypeRepository)
        {
            _sponsorTypeRepository = sponsorTypeRepository;
        }


        [HttpGet]
        [Route("GetAllSponsorTypes")]
        public async Task<ActionResult> GetAllSponsorTypesAsync()
        {
            try
            {
                var results = await _sponsorTypeRepository.getAllSponsorTypesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpPost]
        [Route("AddSponsorType")]
        public async Task<IActionResult> AddEvent(SponsorTypeViewModel stm)
        {
            //var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
            var Tevent = new SponsorType { Description = stm.Type };

            try
            {
                _sponsorTypeRepository.Add(Tevent);
                await _sponsorTypeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }

        [HttpPut]
        [Route("UpdateSponsorType")]

        public async Task<ActionResult> UpdateSponsor(int id, SponsorTypeViewModel stm)
        {



            try
            {
                //var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
                var existing = await _sponsorTypeRepository.getSponsorTypesAsync(id);
                //var tpyID = existingType.TypeID;

                if (existing == null) return NotFound("Could not find");

                existing.Description = stm.Type;


                if (await _sponsorTypeRepository.SaveChangesAsync())
                {
                    return Ok("Type updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");

        }

        [HttpDelete]
        [Route("DeleteSponsorType")]
        public async Task<IActionResult> DeleteSponsorType(int id)
        {
            try
            {
                var existing = await _sponsorTypeRepository.getSponsorTypesAsync(id);
                if (existing == null) return NotFound();


                _sponsorTypeRepository.Delete(existing);

                if (await _sponsorTypeRepository.SaveChangesAsync())
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

        [HttpGet]
        [Route("GetNameByID")]

        public async Task<IActionResult> GetNameByID(int id)
        {

            var results = await _sponsorTypeRepository.getNameById(id);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }


    }
}
