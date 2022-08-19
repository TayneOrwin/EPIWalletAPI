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
    public class EmployeeBankingDetailsController : ControllerBase
    {
        private readonly IEmployeeBankingDetailsRepository _bankingDetailsRepository;

        public EmployeeBankingDetailsController(IEmployeeBankingDetailsRepository bankingDetailsRepository)
        {
            _bankingDetailsRepository = bankingDetailsRepository;
        }


        [HttpGet]
        [Route("GetAllBankingDetails")]
        public async Task<ActionResult> GetAllBankingDetails()
        {
            try
            {
                var results = await _bankingDetailsRepository.getAllEmployeeBankingDetailsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpPost]
        [Route("AddBankingDetails")]
        public async Task<IActionResult> AddBankingDetails(BankingDetailsViewModel bdvm)
        {

            var Tevent = new EmployeeBankingDetails { AccountNunmber = bdvm.AccountNunmber, AccountTypeID = bdvm.AccountTypeID, EmployeeID = bdvm.EmployeeID, Branch = bdvm.Branch, Bank = bdvm.Bank,  };

            try
            {
                _bankingDetailsRepository.Add(Tevent);
                await _bankingDetailsRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }

        [HttpPut]
        [Route("UpdateBankingDetails")]

        public async Task<ActionResult> UpdateBankingDetails(int id, BankingDetailsViewModel bdvm)
        {

            try
            {
                var existing = await _bankingDetailsRepository.getEmployeeBankingDetailsAsync(id);


                if (existing == null) return NotFound("Could not find employee banking details");

                existing.AccountNunmber = bdvm.AccountNunmber;
                existing.AccountTypeID = bdvm.AccountTypeID;
                existing.Bank = bdvm.Bank;
                existing.Branch = bdvm.Branch;
                existing.EmployeeID = bdvm.EmployeeID;

           


                if (await _bankingDetailsRepository.SaveChangesAsync())
                {
                    return Ok("event updated successfully");
                }

            }

            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");

        }

        [HttpDelete]
        [Route("DeleteBankingDetails")]
        public async Task<IActionResult> DeleteBankingDetails(int id)
        {
            try
            {
                var existing = await _bankingDetailsRepository.getEmployeeBankingDetailsAsync(id);
                if (existing == null) return NotFound();


                _bankingDetailsRepository.Delete(existing);

                if (await _bankingDetailsRepository.SaveChangesAsync())
                {
                    return Ok("Details deleted successfully");
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
