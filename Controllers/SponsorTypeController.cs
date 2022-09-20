using EPIWalletAPI.Models;
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
        public async Task<object> AddSponsorType(SponsorTypeViewModel stvm)
        {

            var description = new SponsorType { Description = stvm.Description };

            try
            {
                _sponsorTypeRepository.Add(description);
                await _sponsorTypeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });



        }


        [HttpPut]
        [Route("UpdateSponsorType")]

        public async Task<object> UpdateSponsorType(string description, SponsorTypeViewModel stvm)
        {



            try
            {
                var existingSponsorType = await _sponsorTypeRepository.getSponsorType(description);

                if (existingSponsorType == null) return NotFound("Could not find type: " + description);

                existingSponsorType.Description = stvm.Description;


                if (await _sponsorTypeRepository.SaveChangesAsync())
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
        [Route("DeleteSponsorType")]
        public async Task<IActionResult> DeleteSponsorType(string Description)
        {
            try
            {
                var existingSponsorType = await _sponsorTypeRepository.getSponsorType(Description);
                if (existingSponsorType == null) return NotFound();


                _sponsorTypeRepository.Delete(existingSponsorType);

                if (await _sponsorTypeRepository.SaveChangesAsync())
                {
                    return Ok("sponsor type updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchSponsorTypes")]

        public async Task<ActionResult<IEnumerable<SponsorType>>> Search(string description)
        {
            try
        {
                var results = await _sponsorTypeRepository.Search(description);

                if (results != null)
            {
                return Ok(results);
            }
                return NotFound("Could not find the requested Sponsor Type");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }


        }


    }
}
