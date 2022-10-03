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
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISponsorTypeRepository _sponsorTypeRepository;
        //return data from the database

        //dependency injection
        public SponsorController(ISponsorRepository sponsorRepository, IEventRepository eventRepository, ISponsorTypeRepository sponsorTypeRepository)
        {
           _sponsorRepository = sponsorRepository;
            _eventRepository = eventRepository;
            _sponsorTypeRepository = sponsorTypeRepository;
        }


        [HttpGet]
        [Route("GetAllSponsors")]
        public async Task<ActionResult> GetAllSponsorsAsync()
        {
            try
            {
                var results = await _sponsorRepository.getAllSponsorsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddSponsor")]
        public async Task<IActionResult> AddSponsor(SponsorViewModel svm)
        {

            var sponsorType = await _sponsorTypeRepository.getSponsorType(svm.SponsorType);
            var eventID = await _eventRepository.getIdByName(svm.Event);
            var TSponsor = new Sponsor { EventID = eventID, name = svm.name, Surname = svm.Surname, Amount = svm.Amount, Company=svm.Company,Email=svm.Email, SponsorTypeID = sponsorType.SponsorTypeID, Event = svm.Event, SponsorType = svm.SponsorType };

            if (svm.SponsorType == null || svm.Event == null || svm.Event == "Events" || svm.SponsorType == "Types")
            {
                return Ok(new { code = 401, message = "not found" });
            }else
            try
            {
                
                    _sponsorRepository.Add(TSponsor);
                    await _sponsorRepository.SaveChangesAsync();
                    return Ok(new { code = 200, message = "Added" });
                
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            



        }



        [HttpPut]
        [Route("UpdateSponsor")]

        public async Task<ActionResult> UpdateSponsor(string name, SponsorViewModel svm)
        {



            try
            {
               // var existingType = await _sponsorTypeRepository.getSponsorTypesByIDAsync(svm.TypeID);
                var existingEventID = await _eventRepository.getIdByName(svm.Event);
                var existingSponsor = await _sponsorRepository.getSponsorAsync(name);
                var typeID = await _sponsorTypeRepository.getSponsorType(svm.SponsorType);
                var tID = typeID.SponsorTypeID;
                //var typeID = existingType.SponsorTypeID;

                if (existingSponsor == null) return NotFound("Could not find sponsor: " + name);

                if (existingSponsor != null || svm.SponsorType != null || svm.Event != null || svm.Event != "Events" || svm.SponsorType != "Types")
                {
                    existingSponsor.EventID = existingEventID;
                    existingSponsor.Event = svm.Event;
                    existingSponsor.name = svm.name;
                    existingSponsor.Surname = svm.Surname;
                    existingSponsor.Amount = svm.Amount;
                    existingSponsor.Company = svm.Company;
                    existingSponsor.Email = svm.Email;
                    existingSponsor.SponsorType = svm.SponsorType;
                    existingSponsor.SponsorTypeID = tID;

                    await _sponsorRepository.SaveChangesAsync();
                    return Ok(new { code = 200, message = "Updated" });
                }

                else
                if (existingSponsor == null || svm.SponsorType == null || svm.Event == null || svm.Event == "Events" || svm.SponsorType == "Types")
                {
                    return Ok(new {code = 401, message = "sponsor updated successfully" });
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }





        [HttpDelete]
        [Route("DeleteSponsor")]
        public async Task<IActionResult> DeleteSponsor(string name)
        {
            try
            {
                var existingSponsor = await _sponsorRepository.getSponsorAsync(name);
                if (existingSponsor == null) return NotFound();


                _sponsorRepository.Delete(existingSponsor);

                if (await _sponsorRepository.SaveChangesAsync())
                {
                    return Ok("sponsor deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("SearchSponsor")]

        public async Task<ActionResult<IEnumerable<Sponsor>>> Search(string name)
        {
            try
            {
                var results = await _sponsorRepository.Search(name);
                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested sponsor");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the daatabase");
            }


        }







        }
    }
