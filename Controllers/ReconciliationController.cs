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

    public class ReconciliationController : ControllerBase
    {

        private readonly IReconciliationRepository _reconciliationRepository;

        public ReconciliationController(IReconciliationRepository reconRepository)
        {
            _reconciliationRepository = reconRepository;
        }


        [HttpGet]
        [Route("GetAllRecons")]
        public async Task<ActionResult> GetAllRecons()
        {
            try
            {
                var results = await _reconciliationRepository.getAllReconsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }









        [HttpPost]
        [Route("AddRecon")]
        public async Task<IActionResult> AddRecon(ReconViewModel avm)
        {

            var Tevent = new Models.Entities.Reconciliation { Balance  = avm.Balance,  ExpenseLineID = avm.ExpenseLineID };

            try
            {
                _reconciliationRepository.Add(Tevent);
                await _reconciliationRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }






    }
}
