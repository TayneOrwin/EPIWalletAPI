using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.Suburb;
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
    public class SuburbController : ControllerBase
    {
        private readonly ISuburbRepository _suburbRepository;

        public SuburbController(ISuburbRepository suburbRepository)
        {
            _suburbRepository = suburbRepository;
        }

        [HttpGet]
        [Route("GetAllSuburb")]

        public async Task<ActionResult> GetAllSuburb()
        {


            try
            {
                var results = await _suburbRepository.getAllSuburbsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost]
        [Route("AddSuburb")]
        public async Task<IActionResult> AddSuburb(SuburbViewModel cvm)
        {

            var Taccounttype = new Suburb { SuburbDesctiption = cvm.Description, CityID= cvm.CityID};
            var CheckType = await _suburbRepository.getSuburbAsync(cvm.Description);

            if (CheckType != null)
            {
                return Ok(new { code = 401, message = "City Already Exists !!!!!" });
            }
            try
            {
                _suburbRepository.Add(Taccounttype);
                await _suburbRepository.SaveChangesAsync();
                return Ok(new { code = 200 });
            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }





        }

        [HttpPut]
        [Route("UpdateSuburb")]

        public async Task<object> UpdateSuburb(string id, SuburbViewModel cvm)
        {



            try
            {
                var city = await _suburbRepository.getSuburbAsync(id);

                if (city == null) return NotFound("Could not find suburb ");

                city.SuburbDesctiption = cvm.Description;
                city.CityID = cvm.CityID;


                if (await _suburbRepository.SaveChangesAsync())
                {
                    return Ok("Suburb updated successfully");
                }


            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }

        [HttpDelete]
        [Route("DeleteSuburb")]
        public async Task<IActionResult> DeleteAccountType(string id)
        {
            try
            {
                var existingCity = await _suburbRepository.getSuburbAsync(id);
                if (existingCity == null) return NotFound();


                _suburbRepository.Delete(existingCity);

                if (await _suburbRepository.SaveChangesAsync())
                {
                    return Ok("Suburb updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchSuburb")]

        public async Task<ActionResult<IEnumerable<Suburb>>> Search(string description)
        {
            try
            {
                var results = await _suburbRepository.Search(description);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Suburb");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }


        }

        [HttpGet]
        [Route("SuburbByCityID")]

        public async Task<ActionResult> CityByProvinceID(int cityID)
        {


            try
            {
                var results = await _suburbRepository.GetSuburbByCityID(cityID);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
