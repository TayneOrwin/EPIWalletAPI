using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
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
    }
}
