using EPIWalletAPI.Models;
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
    public class ReasonForRejectionController : ControllerBase
    {
        private readonly IReasonForRejectionRepository _rejectionRepository;
        //return data from the database

        //dependency injection
        public ReasonForRejectionController(IReasonForRejectionRepository rejectionRepository)
        {
            _rejectionRepository = rejectionRepository;
        }


        [HttpGet]
        [Route("GetAllReasons")]
        public async Task<ActionResult> GetAllReasonsAsync()
        {
            try
            {
                var results = await _rejectionRepository.getAllReasonsForRejectionAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddReason")]
        public async Task<IActionResult> AddReason(ReasonForRejectionViewModel evm)
        {

            var Tevent = new ReasonForRejection {ApprovalID=evm.ApprovalID,Reason=evm.Reason };
            var CheckType = await _rejectionRepository.getReasonForRejectionAsync(evm.Reason);

            if (CheckType != null)
            {
                return Ok(new { code = 401, message = "Type Already Exists !!!!!" });
            }
            try
            {
                _rejectionRepository.Add(Tevent);
                await _rejectionRepository.SaveChangesAsync();
                return Ok(new { code = 200 });
            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            



        }

        [HttpPut]
        [Route("UpdateReason")]

        public async Task<object> UpdateReason(string reason, ReasonForRejectionViewModel rvm)
        {



            try
            {
                var existingReason = await _rejectionRepository.getReasonForRejectionAsync(reason);

                if (existingReason == null)
                {
                    return NotFound("Could not find Reason ID: " + reason);
                }

                existingReason.Reason = rvm.Reason;


                if (await _rejectionRepository.SaveChangesAsync())
                {
                    return Ok("Reason updated successfully");
                }


            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }

        [HttpDelete]
        [Route("DeleteReason")]
        public async Task<IActionResult> DeleteReason(string reason)
        {
            try
            {
                var existingReason = await _rejectionRepository.getReasonForRejectionAsync(reason);
                if (existingReason == null) return NotFound();


                _rejectionRepository.Delete(existingReason);

                if (await _rejectionRepository.SaveChangesAsync())
                {
                    return Ok("Reason updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchReason")]

        public async Task<ActionResult<IEnumerable<ReasonForRejection>>> Search(string reason)
        {
            try
            {
                var results = await _rejectionRepository.Search(reason);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Reason");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }


        }


    }










}
