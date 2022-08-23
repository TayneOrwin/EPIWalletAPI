using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.Vendor;
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
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;
        //return data from the database

        //dependency injection
        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }


        [HttpGet]
        [Route("GetAllVendors")]
        public async Task<ActionResult> GetAllVendorsAsync()
        {
            try
            {
                var results = await _vendorRepository.getAllVendorsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddVendor")]
        public async Task<IActionResult> AddVendor(VendorViewModel vvm)
        {

            var Tvendor = new Vendors { Name = vvm.Name, Description = vvm.Description, Availability = vvm.Availability};

            try
            {
                _vendorRepository.Add(Tvendor);
                await _vendorRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



        [HttpPut]
        [Route("UpdateVendor")]

        public async Task<ActionResult> UpdateVendor(int id, VendorViewModel vvm)
        {



            try
            {
                var existingVendor = await _vendorRepository.getVendorAsync(id);

                if (existingVendor == null) return NotFound("Could not find vendor: " + id);

                existingVendor.Name = vvm.Name;
                existingVendor.Description = vvm.Description;
                existingVendor.Availability = vvm.Availability;
          


                if (await _vendorRepository.SaveChangesAsync())
                {
                    return Ok("vendor updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }





        [HttpDelete]
        [Route("DeleteVendor")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            try
            {
                var existingVendor = await _vendorRepository.getVendorAsync(id);
                if (existingVendor == null) return NotFound();


                _vendorRepository.Delete(existingVendor);

                if (await _vendorRepository.SaveChangesAsync())
                {
                    return Ok("vendor deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("SearchVendor")]
        public async Task<ActionResult<IEnumerable<Vendors>>> Search(string name) // IEnumerable used for iterating through collection of a type??
        {
            try
            {
                var result = await _vendorRepository.Search(name);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Could not find the requested employee");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("GetIdByName")]

        public async Task<IActionResult> GetIdByTitle(string name)
        {

            var results = await _vendorRepository.getIdByName(name);

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
        [Route("GetIdByNameDesc")]

        public async Task<IActionResult> GetIdByNameDesc(string name, string description)
        {

            var results = await  _vendorRepository.getIdByNameDescription(name, description);

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
        [Route("GetNameByID")]

        public async Task<IActionResult> GetNameByID(int id)
        {

            var results = await _vendorRepository.GetNameByID(id);

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
