﻿using EPIWalletAPI.Models.Entities;
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
    public class VendorTypeController : ControllerBase
    {
        private readonly IVendorTypeRepository _vendorTypeRepository;

        public VendorTypeController(IVendorTypeRepository vendorTypeRepository)
        {
            _vendorTypeRepository = vendorTypeRepository;
        }


        [HttpGet]
        [Route("GetAllVendorTypes")]
        public async Task<ActionResult> GetAllVendorTypesAsync()
        {
            try
            {
                var results = await _vendorTypeRepository.getAllVendorTypesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpPost]
        [Route("AddVendorType")]
        public async Task<IActionResult> AddEvent(VendorTypeViewModel vtm)
        {
            //var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
            var Tevent = new VendorType { Type =vtm.Type };

            try
            {
                _vendorTypeRepository.Add(Tevent);
                await _vendorTypeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }
        [HttpPut]
        [Route("UpdateVendorType")]

        public async Task<ActionResult> UpdateEvent(int id, VendorTypeViewModel vtm)
        {



            try
            {
                //var existingType = await _expenseTypeRepository.getExpenseType(evm.Type);
                var existing = await _vendorTypeRepository.getVendorTypesAsync(id);
                //var tpyID = existingType.TypeID;

                if (existing == null) return NotFound("Could not find" );

                existing.Type = vtm.Type;


                if (await _vendorTypeRepository.SaveChangesAsync())
                {
                    return Ok("Type updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");

        }

        [HttpDelete]
        [Route("DeleteVendorType")]
        public async Task<IActionResult> DeleteVendorType(int id)
        {
            try
            {
                var existing= await _vendorTypeRepository.getVendorTypesAsync(id);
                if (existing == null) return NotFound();


                _vendorTypeRepository.Delete(existing);

                if (await _vendorTypeRepository.SaveChangesAsync())
                {
                    return Ok("event deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

    }
}
