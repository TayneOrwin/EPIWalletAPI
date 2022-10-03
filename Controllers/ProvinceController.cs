using EPIWalletAPI.Models.Province;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IConfiguration _configuration;

        public ProvinceController(IProvinceRepository provinceRepository, IConfiguration configuration)
        {
            _provinceRepository = provinceRepository;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllProvinces")]
        public async Task<ActionResult> GetAllRolessAsync()
        {
            try
            {
                var results = await _provinceRepository.getAllProvinceAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpPost]
        [Route("AddProvince")]
        public async Task<IActionResult> AddRole(ProvinceViewModel pvm)
        {

            var Tevent = new Models.Entities.Province { ProvinceDesctiption = pvm.Description };

            try
            {
                _provinceRepository.Add(Tevent);
                await _provinceRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }


        [HttpPut]
        [Route("UpdateProvince")]

        public async Task<ActionResult> UpdateProvince(string name, ProvinceViewModel pvm)
        {



            try
            {
                var existing = await _provinceRepository.getProvinceAsync(name);

                if (existing == null) return NotFound("Could not find province: " + name);


                existing.ProvinceDesctiption = pvm.Description;



                if (await _provinceRepository.SaveChangesAsync())
                {
                    return Ok("Role updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");


        }

        [HttpDelete]
        [Route("DeleteProvince")]
        public async Task<IActionResult> DeleteProvince(string Name)
        {
            try
            {
                var existing = await _provinceRepository.getProvinceAsync(Name);
                if (existing == null) return NotFound();


                _provinceRepository.Delete(existing);

                if (await _provinceRepository.SaveChangesAsync())
                {
                    return Ok("Province deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }



        [HttpGet]
        [Route("GetProvinceByID")]

        
        public async Task<IActionResult> GetNameByID(int id)
        {

            var results = await _provinceRepository.getNameByID(id);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet]
        [Route("GetIDByProvince")]


        public async Task<IActionResult> GetIDByProvince(string name)
        {

            var results = await _provinceRepository.getIDByName(name);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }



        [HttpGet]
        [Route("DataTreeValues")]

        public object DataTreeValues(int ID)
        {
            var list = new List<DataTreeViewModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "select Province.ProvinceID, Province.ProvinceDesctiption, City.CityID, City.CityDesctiption, Suburb.SuburbID, Suburb.SuburbDesctiption from Province Inner join City on Province.ProvinceID = City.ProvinceID Inner join Suburb on City.CityID = Suburb.SuburbID where Province.ProvinceID = "+ID;
            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var results = new DataTreeViewModel
                {
                    CityID = (int)reader["CityID"],
                    City = (string)reader["CityDesctiption"],
                    ProvinceID = (int)reader["ProvinceID"],
                    Province = (string)reader["ProvinceDesctiption"],
                    SuburbID = (int)reader["SuburbID"],
                    Suburb = (string)reader["SuburbDesctiption"]
                };
                list.Add(results);
            }
            return list;
        }





        

    }
}
