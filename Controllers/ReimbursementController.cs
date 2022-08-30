using EPIWalletAPI.Models;
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
    public class ReimbursementController : ControllerBase

    {
        private readonly IReimbursementRepository _reimbursementRepository;

        public ReimbursementController(IReimbursementRepository reimbursementRepository)
        {
            _reimbursementRepository = reimbursementRepository;
        }


        [HttpGet]
        [Route("GetAllReimbursements")]
        public async Task<ActionResult> GetAllReimbursements()
        {
            try
            {
                var results = await _reimbursementRepository.getAllReimbursementsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }









        [HttpPost]
        [Route("AddReimbursement")]
        public async Task<IActionResult> AddReimbursement(ReimbursementViewModel avm)
        {

            var Tevent = new Models.Entities.Reimbursement { amount = avm.amount, DateTime = avm.DateTime, ReconID=avm.ReconID };

            try
            {
                _reimbursementRepository.Add(Tevent);
                await _reimbursementRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }












    }
}
