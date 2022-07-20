﻿using EPIWalletAPI.Models.Employee;
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
            var address = new EmployeeAddress { Country = eavm.Country, Province = eavm.Province, Suburb = eavm.Suburb, EmployeeID = eavm.EmployeeID, AddressLine1 = eavm.AddressLine1, AddressLine2 = eavm.AddressLine2 };

            try
            {
                _employeeAddressRepository.Add(address);
                await _employeeAddressRepository.SaveChangesAsync();
            }
            catch(Exception err)
            {
                return Ok(err);
            }
            return Ok("Success");

        }

        [HttpPut]
        [Route("UpdateEmployeeAddress")]

        public async Task<IActionResult> UpdateEmployeeAddress(string name, EmployeeAddressViewModel eavm)
        {
            var results = await _employeeAddressRepository.getEmployeeAddress(name);
            try
            {
                if (results == null) return NotFound("Could not finf " + name);

                results.Country = eavm.Country;
                results.Province = eavm.Province;
                results.Suburb = eavm.Suburb;
                results.EmployeeID = eavm.EmployeeID;
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

        async Task<IActionResult> DeleteEmployeeAddress(string address)
        {
            try
            {
                var existing = await _employeeAddressRepository.getEmployeeAddress(address);

                if (existing == null) return NotFound("Could not find " + existing);

                _employeeAddressRepository.Delete(address);

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


    }
}
