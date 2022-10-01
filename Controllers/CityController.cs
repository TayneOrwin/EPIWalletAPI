using EPIWalletAPI.Models.City;
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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("GetAllCities")]

        public async Task<ActionResult> GetAllCities()
        {


            try
            {
                var results = await _cityRepository.getAllCitiesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost]
        [Route("AddAccountType")]
        public async Task<IActionResult> AddAccountType(City cvm)
        {

            var Taccounttype = new City { CityDesctiption = cvm.CityDesctiption,ProvinceID = cvm.ProvinceID };
            var CheckType = await _cityRepository.getCityAsync(cvm.CityDesctiption);

            if (CheckType != null)
            {
                return Ok(new { code = 401, message = "City Already Exists !!!!!" });
            }
            try
            {
                _cityRepository.Add(Taccounttype);
                await _cityRepository.SaveChangesAsync();
                return Ok(new { code = 200 });
            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }





        }

        [HttpPut]
        [Route("UpdateAccountType")]

        public async Task<object> UpdateAccountType(string id, CityViewModel cvm)
        {



            try
            {
                var city = await _cityRepository.getCityAsync(id);

                if (city == null) return NotFound("Could not find city ");

                city.CityDesctiption = cvm.CityDescription;
                city.ProvinceID = cvm.ProvinceID;


                if (await _cityRepository.SaveChangesAsync())
                {
                    return Ok("City updated successfully");
                }


            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }

        [HttpDelete]
        [Route("DeleteAccountType")]
        public async Task<IActionResult> DeleteAccountType(string id)
        {
            try
            {
                var existingCity = await _cityRepository.getCityAsync(id);
                if (existingCity == null) return NotFound();


                _cityRepository.Delete(existingCity);

                if (await _cityRepository.SaveChangesAsync())
                {
                    return Ok("City updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchAccountType")]

        public async Task<ActionResult<IEnumerable<City>>> Search(string description)
        {
            try
            {
                var results = await _cityRepository.Search(description);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested City");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }


        }

    }
}

