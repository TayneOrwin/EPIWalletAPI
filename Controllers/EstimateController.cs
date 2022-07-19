using EPIWalletAPI.Models.Estimate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EPIWalletAPI.ViewModels;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IEstimateRepository _estimateRepository;

        public EstimateController(IEstimateRepository employeeRepository)
        {
            _estimateRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetAllEstimate")]

        public async Task<ActionResult> GetAllEstimatesAsync()
        {
            try
            {
                var results = await _estimateRepository.getAllEstimatesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        [Route("AddEstimate")]

        public async Task<ActionResult> AddEstimate(EstimateViewModel evm)
        {

            var estimate = new Estimates {EstimateID = evm.EstimateID, Amount = evm.Amount};

            try
            {
                _estimateRepository.Add(estimate);
                await _estimateRepository.SaveChangesAsync();

            }
            catch (Exception err)
            {
                return Ok(err); ;
            }

            return Ok("Success");
        }


        [HttpPut]
        [Route("UpdateEstimate")]

        public async Task<ActionResult> UpdateEstimate(int amount, EstimateViewModel evm)
        {

            try
            {
                var existingEstimate = await _estimateRepository.getEstimateAsync(amount);

                if (existingEstimate == null) return NotFound("Could not find event: " + amount);

                existingEstimate.EstimateID = evm.EstimateID;
                existingEstimate.Amount = evm.Amount;
                
                


                if (await _estimateRepository.SaveChangesAsync())
                {
                    return Ok("estimate updated successfully");
                }

            }

            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");

        }

        [HttpDelete]
        [Route("DeleteEstimate")]
        public async Task<IActionResult> DeleteEstimate(int Amount)
        {
            try
            {
                var existingEstimate = await _estimateRepository.getEstimateAsync(Amount);
                if (existingEstimate == null) return NotFound();


                _estimateRepository.Delete(existingEstimate);

                if (await _estimateRepository.SaveChangesAsync())
                {
                    return Ok("Estimate deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest("Internal error");
        }


    }
}
