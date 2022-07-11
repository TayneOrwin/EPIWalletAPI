using EPIWalletAPI.Models.Employee;
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
    public class EmployeeAddressController : ControllerBase
    {

        private readonly IEmployeeAddressRepository _employeeAddressRepository;

       
        public EmployeeAddressController(IEmployeeAddressRepository employeeAddressRepository)
        {
            _employeeAddressRepository = employeeAddressRepository;
        }

        [HttpGet]
        [Route("GetAllEmployeeAddresses")]

        public async Task<ActionResult> GetAllEmployeeAddresses()
        {
            try
            {
                var results = await _employeeAddressRepository.getAllEmployeeAddress();
                return Ok(results);
            }
            catch(Exception)
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
