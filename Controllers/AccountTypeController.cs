using EPIWalletAPI.Models;
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


        //[HttpPost]
        //[Route("AddAccountType")]
        //public async Task<IActionResult> AddAccountType(BankingDetailsViewModel bdvm)
        //{

        //    var Tevent = new EmployeeBankingDetails { AccountNunmber = bdvm.AccountNunmber, AccountTypeID = bdvm.AccountTypeID, EmployeeID = bdvm.EmployeeID, Branch = bdvm.Branch, Bank = bdvm.Bank, };

        //    try
        //    {
        //        _bankingDetailsRepository.Add(Tevent);
        //        await _bankingDetailsRepository.SaveChangesAsync();
        //    }




        //    catch (Exception)
        //    {
        //        return BadRequest("Error");
        //    }

        //    return Ok("Success");



        //}

    }
}
