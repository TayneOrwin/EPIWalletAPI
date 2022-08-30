using EPIWalletAPI.Models;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public ReconciliationController(IReconciliationRepository reconRepository, IConfiguration configuration)
        {
            _reconciliationRepository = reconRepository;
            _configuration = configuration;
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


        [HttpGet]
        [Route("GetSpecificReceiptAndTotal")]

        public object GetSpecificReceiptAndTotal(int id)
        {
            var list = new List<ReceiptViewModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "select expenseLines.ExpenseLineID, sum(receipts.Amount) as [Total receipts amount for Specific Line ] from expenseLines inner join receipts on expenseLines.ExpenseLineID = receipts.ExpenseLineID where expenseLines.ExpenseLineID = " + id + " group by expenseLines.ExpenseLineID";
            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var result = new ReceiptViewModel()
                {
                    amount = (double)reader["Total receipts amount for Specific Line "],
                    ExpenseLineID = (int)reader["ExpenseLineID"]
                    
                };

                list.Add(result);
            }

            return list;

        }

        [HttpGet]
        [Route("GetSpecificTopUpRequestsAndTotal")]

        public object GetSpecificTopUpRequestsAndTotal(int id)
        {
            var list = new List<TopUpRequestViewModel>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "select expenseLines.ExpenseLineID, sum(topUpRequests.Amount) as [Total topup amount for Specific Line] from expenseLines inner join topUpRequests on expenseLines.ExpenseLineID = topUpRequests.ExpenseLineID where expenseLines.ExpenseLineID = " + id + " group by expenseLines.ExpenseLineID";
            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var result = new TopUpRequestViewModel()
                {
                    amount = (double)reader["Total topup amount for Specific Line"],
                    ExpenseLineID = (int)reader["ExpenseLineID"]

                };

                list.Add(result);
            }

            return list;

        }



    }
}
