using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models.ProofOfPayment;
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
    public class ProofOfPaymentController : ControllerBase
    {

        private readonly IProofOfPaymentRepository _proofofpaymentRepository;


        public ProofOfPaymentController(IProofOfPaymentRepository proofofpaymentRepository)
        {
            _proofofpaymentRepository = proofofpaymentRepository;
        }


        [HttpGet]
        [Route("GetAllPOP")]
        public async Task<ActionResult> GetAllPOP()
        {
            try
            {
                var results = await _proofofpaymentRepository.getAllPOPAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }

        [HttpPost]
        [Route("AddPOP")]
        public async Task<IActionResult> AddPOP(ProofOfPaymentViewModel pvm)
        {

            var Tevent = new Models.Entities.ProofOfPayment { ExpenseLineID = pvm.ExpenseLineID, File = pvm.File };

            try
            {
                _proofofpaymentRepository.Add(Tevent);
                await _proofofpaymentRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }

        [HttpDelete]
        [Route("DeletePOP")]
        public async Task<IActionResult> DeletePOP(int id)
        {
            try
            {
                var existingPOP = await _proofofpaymentRepository.getPOPAsync(id);
                if (existingPOP == null) return NotFound();


                _proofofpaymentRepository.Delete(existingPOP);

                if (await _proofofpaymentRepository.SaveChangesAsync())
                {
                    return Ok("proof of payment deleted successfully");
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



                var Tevent = new Models.Entities.ProofOfPayment { File = wallpaperImage, ExpenseLineID = id };

                try
                
                {
                    _proofofpaymentRepository.Add(Tevent);
                    await _proofofpaymentRepository.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest("Error");
                }


                return Ok("Success");



            }
        }

        // GET api/values/2
        [HttpGet]
        [Route("GetImage")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            ProofOfPayment currentPOP= await _proofofpaymentRepository.getPOPAsync(id);

            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);

            Response.Content = new StreamContent(new MemoryStream(currentPOP.File));
            Response.Content.Headers.ContentType =
    new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return Response;

        }

    }
}
