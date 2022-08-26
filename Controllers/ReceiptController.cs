using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

    public class ReceiptController : ControllerBase
    {


        private readonly IReceiptRepository _receiptRepository;
  
        public ReceiptController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }


        [HttpGet]
        [Route("GetAllReceipts")]
        public async Task<ActionResult> GetAllReceiptsAsync()
        {
            try
            {
                var results = await _receiptRepository.getAllReceiptsAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }









        [HttpPost]
        [Route("AddReceipt")]
        public async Task<IActionResult> AddReceipt(ReceiptViewModel avm)
        {

            var Tevent = new Models.Entities.Receipt { amount = avm.amount, File = avm.file, ExpenseLineID = avm.ExpenseLineID};

            try
            {
                _receiptRepository.Add(Tevent);
                await _receiptRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }



     

        [HttpDelete]
        [Route("DeleteReceipt")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            try
            {
                var existingReceipt = await _receiptRepository.getReceiptAsync(id);
                if (existingReceipt == null) return NotFound();


               _receiptRepository.Delete(existingReceipt);

                if (await _receiptRepository.SaveChangesAsync())
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
        public async Task<IActionResult> Post(int id,double amount)
        {

            var file = HttpContext.Request.Form.Files[0];
            byte[] wallpaperImage;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                wallpaperImage = memoryStream.ToArray();



                var Tevent = new Models.Entities.Receipt { amount = amount, File = wallpaperImage, ExpenseLineID = id };

                try
                {
                    _receiptRepository.Add(Tevent);
                    await _receiptRepository.SaveChangesAsync();
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
                Receipt currentReceipt = await _receiptRepository.getReceiptAsync(id);

                HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);

                Response.Content = new StreamContent(new MemoryStream(currentReceipt.File));
                Response.Content.Headers.ContentType =
        new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
                return Response;

        }




















    }














}




