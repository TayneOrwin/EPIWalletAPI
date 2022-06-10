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
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        //return data from the database
      
        //dependency injection
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        [HttpGet]
        [Route("GetAllEvents")]
        public async Task<ActionResult> GetAllEventsAsync()
        {
            try
            {
                var results = await _eventRepository.getAllEventsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddEvent")]
public async Task<IActionResult> AddEvent(EventViewModel evm)
        {

            var Tevent = new Event { TypeID = evm.TypeID, name = evm.name, description = evm.description, date = evm.date };

            try
            {
                _eventRepository.Add(Tevent);
                await _eventRepository.SaveChangesAsync();
            }




            catch(Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



        [HttpPut]
        [Route("UpdateEvent")]

        public async Task<ActionResult> UpdateEvent(string name, EventViewModel evm)
        {

          

            try
            {
                var existingEvent = await _eventRepository.getEventAsync(name);

                if (existingEvent == null) return NotFound("Could not find event: "+ name);

                existingEvent.TypeID = evm.TypeID;
                existingEvent.name = evm.name;
                existingEvent.description = evm.description;
                existingEvent.date = evm.date;


                if (await _eventRepository.SaveChangesAsync())
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
        [Route("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(string name)
        {
            try
            {
                var existingEvent = await _eventRepository.getEventAsync(name);
                if (existingEvent == null) return NotFound();
     

                _eventRepository.Delete(existingEvent);

                if (await _eventRepository.SaveChangesAsync())
                {
                    return Ok("event deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,"Error");
            }

            return BadRequest();
        }









    }
}
