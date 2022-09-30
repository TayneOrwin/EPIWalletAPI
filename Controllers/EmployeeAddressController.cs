using EPIWalletAPI.Models.Employee;
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


        [HttpPost]
        [Route("AddEmployeeAddress")]

        public async Task<IActionResult> AddEmployeeAddress(EmployeeAddressViewModel eavm)
        {
            var address = new EmployeeAddress {  ProvinceID = eavm.ProvinceID,  EmployeeID = eavm.EmployeeID, AddressLine1 = eavm.AddressLine1, AddressLine2 = eavm.AddressLine2 };

            try
            {
                _employeeAddressRepository.Add(address);
                await _employeeAddressRepository.SaveChangesAsync();
            }
            catch(Exception err)
            {
                return Ok("Make sure employee exists");
            }
            return Ok("Success");

        }

        [HttpPut]
        [Route("UpdateEmployeeAddress")]

        public async Task<IActionResult> UpdateEmployeeAddress(int id, EmployeeAddressViewModel eavm)
        {
            var results = await _employeeAddressRepository.getEmployeeAddress(id);
            try
            {
                if (results == null) return NotFound("Could not fin ");

                
                results.ProvinceID = eavm.ProvinceID;
               
                //results.EmployeeID = eavm.EmployeeID; not able to change assigned employee.
                results.AddressLine1 = eavm.AddressLine1;
                results.AddressLine2 = eavm.AddressLine2;

                if (await _employeeAddressRepository.SaveChangesAsync()) // if true
                {
                    return Ok("Address updated successfully");
                }

                return Ok("Success");
            }
            catch(Exception err)
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
                var existing = await _employeeAddressRepository.getEmployeeAddress(id);

                if (existing == null) return NotFound("Could not find " + existing);

                _employeeAddressRepository.Delete(existing);

                if (await _employeeAddressRepository.SaveChangesAsync())
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
       
        //[HttpGet]
        //[Route("SearchEmployeeAddress")]
        //public async Task<ActionResult<IEnumerable<EmployeeAddress>>> Search(string name)
        //{
        //    try
        //    {
        //        var results = await _employeeAddressRepository.Search(name);

        //        if(results != null)
        //        {
        //            return Ok(results);
        //        }
        //        return NotFound("Could not find the requested address");

        //    }
        //    catch (Exception err)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database" + err);
        //    }
        //}

        [HttpGet]
        [Route("GetEmployeesAddress")]

        public async Task<ActionResult<IEnumerable<EmployeeAddress>>> GetEmployeesAddress(int id)
        {
            try
            {
                var results = await _employeeAddressRepository.getEmployeeAddress(id);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Employee");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }

    }
}
