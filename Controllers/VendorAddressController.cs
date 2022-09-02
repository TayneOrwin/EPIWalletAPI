using EPIWalletAPI.Models;
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
    public class VendorAddressController : ControllerBase
    {

        private readonly IVendorAddressRepository _vendorAddressRepository;


        public VendorAddressController(IVendorAddressRepository vendorAddressRepository)
        {
            _vendorAddressRepository = vendorAddressRepository;
        }

        [HttpGet]
        [Route("GetAllVendorAddress")]

        public async Task<ActionResult> GetAllVendorAddress()
        {
            try
            {
                var results = await _vendorAddressRepository.getAllVendorAddressAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("AddVendorAddress")]
        public async Task<ActionResult> AddVendorAddress(VendorAddressViewModel vavm)
        {
            var address = new VendorAddress
            {
                Country = vavm.Country,
                Province = vavm.Province,
                Suburb = vavm.Suburb,
                AddressLine1 = vavm.AddressLine1,
                AddressLine2 = vavm.AddressLine2,
                VendorID = vavm.VendorID
            };

            try
            {
                _vendorAddressRepository.Add(address);
                await _vendorAddressRepository.SaveChangesAsync();
            }
            catch (Exception err)
            {
                return Ok("Make sure vendor exists");
            }
            return Ok("Success");

        }

        [HttpPut]
        [Route("UpdateVendorAddress")]

        public async Task<IActionResult> UpdateVendorAddress(int id, VendorAddressViewModel vavm)
        {
            var results = await _vendorAddressRepository.getVendorAddress(id);
            try
            {
                if (results == null) return NotFound("Could not find " + id);

                results.Country = vavm.Country;
                results.Province = vavm.Province;
                results.Suburb = vavm.Suburb;
                results.VendorID = vavm.VendorID;
                results.AddressLine1 = vavm.AddressLine1;
                results.AddressLine2 = vavm.AddressLine2;

                if (await _vendorAddressRepository.SaveChangesAsync()) // if true
                {
                    return Ok("Address updated successfully");
                }

                return Ok("Success");
            }
            catch (Exception err)
            {
                return BadRequest("Error " + err);
            }

        }

        [HttpDelete]
        [Route("DeleteEmployeeAddress")]

        public async Task<IActionResult> DeleteEmployeeAddress(int id)
        {
            try
            {
                var existing = await _vendorAddressRepository.getVendorAddress(id);

                if (existing == null) return NotFound("Could not find " + existing);

                _vendorAddressRepository.Delete(existing);

                if (await _vendorAddressRepository.SaveChangesAsync())
                {
                    return Ok("Success");
                }

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("SearchVendor")]

        public async Task<ActionResult<IEnumerable<VendorAddress>>> Search(string name)
        {
            try
            {
                var results = await _vendorAddressRepository.Search(name);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Expense Type");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }


        [HttpGet]
        [Route("GetVendorAddress")]

        public async Task<ActionResult<IEnumerable<VendorAddress>>> GetVendorAddress(int id)
        {
            try
            {
                var results = await _vendorAddressRepository.getVendorAddress(id);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Vendor");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }

    }
}
