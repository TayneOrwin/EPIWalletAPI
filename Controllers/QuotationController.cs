using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.Quotation;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationRepository _quotationRepository;


        public QuotationController(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }


        [HttpGet]
        [Route("GetQuotations")]
        public async Task<ActionResult> GetAllQuotationsAsync()
        {
            try
            {
                var results = await _quotationRepository.getAllQuotationsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

       
        [HttpDelete]
        [Route("DeleteQuotation")]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            try
            {
                var existingQuotation = await _quotationRepository.getQuotationAsync(id);
                if (existingQuotation == null) return NotFound();


                _quotationRepository.Delete(existingQuotation);

                if (await _quotationRepository.SaveChangesAsync())
                {
                    return Ok("Receipt deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }






        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Post(int id)
        {

            var file = HttpContext.Request.Form.Files[0];
            byte[] wallpaperImage;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                wallpaperImage = memoryStream.ToArray();



                var Tevent = new Models.Entities.Quotation{QuotationID =1,File = wallpaperImage, ExpenseItemID = id };

                try
                {
                    _quotationRepository.Add(Tevent);
                    await _quotationRepository.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest("Error");
                }


                return Ok("Success");



            }
        }

    

    }
}
