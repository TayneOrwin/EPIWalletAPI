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
        //return data from the database

        //dependency injection
        public SponsorController(ISponsorRepository sponsorRepository)
        {
           _sponsorRepository = sponsorRepository;
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

            var TSponsor = new Sponsor { EventID = svm.EventID, name = svm.name, Surname = svm.Surname, Amount = svm.Amount, Company=svm.Company,Email=svm.Email };

            try
            {
                _sponsorRepository.Add(TSponsor);
                await _sponsorRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



        [HttpPut]
        [Route("UpdateSponsor")]

        public async Task<ActionResult> UpdateSponsor(string name, SponsorViewModel svm)
        {



            try
            {
                var existingSponsor = await _sponsorRepository.getSponsorAsync(name);

                if (existingSponsor == null) return NotFound("Could not find sponsor: " + name);

                existingSponsor.EventID = svm.EventID;
                existingSponsor.name = svm.name;
                existingSponsor.Surname = svm.Surname;
                existingSponsor.Amount = svm.Amount;
                existingSponsor.Company = svm.Company;
                existingSponsor.Email = svm.Email;


                if (await _sponsorRepository.SaveChangesAsync())
                {
                    return Ok("sponsor updated successfully");
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
                var results = _sponsorRepository.Search(name);
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
