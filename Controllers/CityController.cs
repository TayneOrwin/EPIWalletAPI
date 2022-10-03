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
        [Route("AddCity")]
        public async Task<IActionResult> AddAccountType(CityViewModel cvm)//fix
        {

            var Taccounttype = new City { CityDesctiption = cvm.CityDescription,ProvinceID = cvm.ProvinceID };
          
         
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
        [Route("UpdateCity")]

        public async Task<IActionResult> UpdateCity(int id, CityViewModel cvm)
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
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteAccountType(string id)
        {
            try
            {
                var existingCity = await _cityRepository.getCityForDeleteAsync(id);
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
        [Route("SearchCity")]

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

        [HttpGet]
        [Route("CityByProvinceID")]

        public async Task<ActionResult> CityByProvinceID(int provinceID)
        {


            try
            {
                var results = await _cityRepository.GetCityByProvinceID(provinceID);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpGet]
        [Route("GetIDByCity")]


        public async Task<IActionResult> GetIDByCity(string name)
        {

            var results = await _cityRepository.getIDByName(name);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }


        


       



    }
}

