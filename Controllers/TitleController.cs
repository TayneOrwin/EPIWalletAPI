using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
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
    public class TitleController : ControllerBase
    {
        private readonly ITitleRepository _titleRepository;

        public TitleController(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        [HttpGet]
        [Route("GetAllTitles")]
        public async Task<ActionResult> GetAllTitlesAsync()
        {
            try
            {
                var results = await _titleRepository.getAllTitleAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddTitle")]
        public async Task<IActionResult> AddReason(TitleViewModel tvm)
        {

            var Ttitle = new Title { Description = tvm.Description};
            var CheckType = await _titleRepository.getTitleAsync(tvm.Description);

            if (CheckType != null)
            {
                return Ok(new { code = 401, message = "Title Already Exists !!!!!" });
            }

            try
            {
                _titleRepository.Add(Ttitle);
                await _titleRepository.SaveChangesAsync();
                return Ok(new { code = 200 });
            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            



        }

        [HttpPut]
        [Route("UpdateTitle")]

        public async Task<object> UpdateTitle(string name, TitleViewModel tvm)
        {



            try
            {
                var existingTitle = await _titleRepository.getTitleAsync(name);

                if (existingTitle == null) return NotFound("Could not find Title ID: " + name);

                existingTitle.Description = tvm.Description;


                if (await _titleRepository.SaveChangesAsync())
                {
                    return Ok("Title updated successfully");
                }


            }




            catch (Exception)
            {
                return Ok(new { code = 401 });
            }

            return Ok(new { code = 200 });


        }

        [HttpDelete]
        [Route("DeleteTitle")]
        public async Task<IActionResult> DeleteTitle(string name)
        {
            try
            {
                var existingTitle = await _titleRepository.getTitleAsync(name);
                if (existingTitle == null) return NotFound();


                _titleRepository.Delete(existingTitle);

                if (await _titleRepository.SaveChangesAsync())
                {
                    return Ok("Title deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchTitle")]

        public async Task<ActionResult<IEnumerable<Title>>> Search(string name)
        {
            try
            {
                var results = await _titleRepository.Search(name);

                if (results != null)
                {
                    return Ok(results);
                }
                return NotFound("Could not find the requested Title");
            }

            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }
        }
    }
}
