using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestListController : ControllerBase
    {
        private readonly IGuestListRepository _guestListRepository;

        public GuestListController(IGuestListRepository guestListRepository)
        {
            _guestListRepository = guestListRepository;
        }

        [HttpGet]
        [Route("GetAllGuestLists")]
        public async Task<ActionResult> GetAllGuestListsAsync()
        {
            try
            {
                var results = await _guestListRepository.getAllGuestListsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpGet]
        [Route("SearchGuestList")]

        public async Task<ActionResult<IEnumerable<GuestList>>> Search(string name)
        {
            try
            {
                var results = await _guestListRepository.Search(name);
                if (results != null)
                {
                    return Ok(results);
                }

                return NotFound("Could not find the requested Event in the database");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }
        }

        [HttpPut]
        [Route("UpdateAttendance")]

        public async Task<ActionResult> UpdateSponsor(int name, GuestListViewModel glvm)
        {



            try
            {
                
                var existingAtt = await _guestListRepository.getAttAsync(name);
                
                //var typeID = existingType.SponsorTypeID;

                if (existingAtt == null) return NotFound("Could not find sponsor: " + name);

                if (existingAtt != null)
                {
                    existingAtt.Attendance = glvm.Attendance;
                    

                    await _guestListRepository.SaveChangesAsync();
                    return Ok(new { code = 200, message = "Updated" });
                }

                else
                if (existingAtt == null)
                {
                    return Ok(new { code = 401, message = "sponsor updated successfully" });
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }
    }
}
