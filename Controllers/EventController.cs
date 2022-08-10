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
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        //return data from the database

        //dependency injection
        public EventController(IEventRepository eventRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _eventRepository = eventRepository;
            _expenseTypeRepository = expenseTypeRepository;
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
            var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
            var Tevent = new Event { TypeID = existingType.TypeID, name = evm.name, description = evm.description, date = evm.date };

            try
            {
                _eventRepository.Add(Tevent);
                await _eventRepository.SaveChangesAsync();
            }




            catch (Exception)
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
                var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
                var existingEvent = await _eventRepository.getEventAsync(name);
                var tpyID = existingType.TypeID;

                if (existingEvent == null) return NotFound("Could not find event: " + name);

                existingEvent.TypeID = tpyID;
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

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchEvent")]

        public async Task<ActionResult<IEnumerable<Event>>> Search(string name)
        {
            try
            {
                var results =  await _eventRepository.Search(name);
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


        [HttpGet]
        [Route("getIdByEventName")]

        public async Task<IActionResult> getIdByEventName(string Name)
        {
            try
            {
                var results = await _eventRepository.getIdByName(Name);
                return Ok(results);
            }
            catch (Exception er)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error" + er);
            }

        }


       


    }
    }
