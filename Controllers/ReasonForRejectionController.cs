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

            try
            {
                _rejectionRepository.Add(Tevent);
                await _rejectionRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }







  

    }
}
