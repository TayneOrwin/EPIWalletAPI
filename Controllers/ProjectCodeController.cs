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
    public class ProjectCodeController : ControllerBase
    {
        private readonly IProjectCodeRepository _projectCodeRepository;
        private readonly ICompanyRepository _companyRepository;

        public ProjectCodeController(IProjectCodeRepository projectCodeRepository, ICompanyRepository companyRepository)
        {
            _projectCodeRepository = projectCodeRepository;
            _companyRepository = companyRepository;
        }


        [HttpGet]
        [Route("GetAllProjectCodes")]
        public async Task<ActionResult> GetAllProjectCodesAsync()
        {
            try
            {
                var results = await _projectCodeRepository.getAllProjectCodesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddProjectCode")]
        public async Task<IActionResult> AddProjectCode(ProjectCodeViewModel pvm)
        {
            var Tprojectcode = new ProjectCode {code = pvm.projectcode};

            try
            {
                _projectCodeRepository.Add(Tprojectcode);
                await _projectCodeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }


        [HttpPut]
        [Route("UpdateProjectCode")]

        public async Task<ActionResult> UpdateProjectCode(string projectcode, ProjectCodeViewModel pvm)
        {



            try
            {
                var existingProjectCode = await _projectCodeRepository.getProjectCodeAsync(projectcode);

                if (existingProjectCode == null) return NotFound("Could not find ProjectCode: " + projectcode);

                existingProjectCode.code = pvm.projectcode;


                if (await _projectCodeRepository.SaveChangesAsync())
                {
                    return Ok("ProjectCode updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }



        [HttpDelete]
        [Route("DeleteProjectCode")]
        public async Task<IActionResult> DeleteProjectCode(string projectcode)
        {
            try
            {
                var existingProjectCode = await _projectCodeRepository.getProjectCodeAsync(projectcode);
                if (existingProjectCode == null) return NotFound();


                _projectCodeRepository.Delete(existingProjectCode);

                if (await _projectCodeRepository.SaveChangesAsync())
                {
                    return Ok("projectcode deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("SearchProjectCode")]

        public async Task<ActionResult<IEnumerable<ProjectCode>>> Search(string projectcode)
        {
            try
            {
                var results = await _companyRepository.Search(projectcode);
                if (results != null)
                {
                    return Ok(results);
                }

                return NotFound("Could not find the requested ProjectCode in the database");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }
        }
    }
}
