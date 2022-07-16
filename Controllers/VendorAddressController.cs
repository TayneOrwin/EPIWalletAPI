using EPIWalletAPI.Models;
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

        public async Task<ActionResult> GetAllVendorAddresses()
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

        //[HttpGet]
        //[Route("getEmployeeAddress")]
        //public async Task<ActionResult> getEmployeeAddress(string province)
        //{

        //}

    }
}
