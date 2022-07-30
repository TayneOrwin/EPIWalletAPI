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
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;
        //return data from the database

        //dependency injection
        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }


        [HttpGet]
        [Route("GetAllGuests")]
        public async Task<ActionResult> GetAllGuestsAsync()
        {
            try
            {
                var results = await _guestRepository.getAllGuestsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddGuest")]
        public async Task<IActionResult> AddGuest(GuestViewModel evm)
        {

            var Tevent = new Guest {Name = evm.Name, Surname = evm.Surname, EmailAddress = evm.EmailAddress };

            try
            {
                _guestRepository.Add(Tevent);
                await _guestRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



        [HttpPut]
        [Route("UpdateGuest")]

        public async Task<ActionResult> UpdateGuest(string name, GuestViewModel gvm)
        {



            try
            {
                var existingGuest = await _guestRepository.getGuestAsync(name);

                if (existingGuest == null) return NotFound("Could not find Guest: " + name);

             
                existingGuest.Name = gvm.Name;
                existingGuest.Surname = gvm.Surname;
                existingGuest.EmailAddress = gvm.EmailAddress;


                if (await _guestRepository.SaveChangesAsync())
                {
                    return Ok("Guest updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }





        [HttpDelete]
        [Route("DeleteGuest")]
        public async Task<IActionResult> DeleteEvent(string Name)
        {
            try
            {
                var existingEvent = await _guestRepository.getGuestAsync(Name);
                if (existingEvent == null) return NotFound();


                _guestRepository.Delete(existingEvent);

                if (await _guestRepository.SaveChangesAsync())
                {
                    return Ok("Guest deleted successfully");
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
