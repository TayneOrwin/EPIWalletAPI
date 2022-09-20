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
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public AccountTypeController(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }

        [HttpGet]
        [Route("GetAllAccountTypes")]

        public async Task<ActionResult> GetAllAccountTypes()
        {


            try
            {
                var results = await _accountTypeRepository.getAllAccountTypesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost]
        [Route("AddAccountType")]
        public async Task<IActionResult> AddAccountType(AccountTypeViewModel atvm)
        {

            var Taccounttype = new AccountType { Description = atvm.Description};

           try
           {
               _accountTypeRepository.Add(Taccounttype);
                await _accountTypeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
               return BadRequest("Error");
           }

            return Ok("Success");



        }

        [HttpPut]
        [Route("UpdateAccountType")]

        public async Task<object> UpdateAccountType(int id, AccountTypeViewModel atvm)
        {



            try
            {
                var existingAccountType = await _accountTypeRepository.getAccountTypeAsync(id);

                if (existingAccountType == null) return NotFound("Could not find AccountType ID: " + id);

                existingAccountType.Description = atvm.Description;


                if (await _accountTypeRepository.SaveChangesAsync())
                {
                    return Ok("AccountType updated successfully");
                }


            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }

        [HttpDelete]
        [Route("DeleteAccountType")]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            try
            {
                var existingAccountType = await _accountTypeRepository.getAccountTypeAsync(id);
                if (existingAccountType == null) return NotFound();


                _accountTypeRepository.Delete(existingAccountType);

                if (await _accountTypeRepository.SaveChangesAsync())
                {
                    return Ok("AccountTypeason updated successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchAccountType")]

        public async Task<ActionResult<IEnumerable<AccountType>>> Search(string description)
        {
            try
            {
                var results = await _accountTypeRepository.Search(description);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Account Type");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }


        }

    }
}
