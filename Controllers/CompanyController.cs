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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IProjectCodeRepository _projectCodeRepository;
        private readonly IEventRepository _eventRepository;

        public CompanyController(ICompanyRepository companyRepository,
                                 IProjectCodeRepository projectCodeRepository,
                                 IEventRepository eventRepository)
        {
            _companyRepository = companyRepository;
            _projectCodeRepository = projectCodeRepository;
            _eventRepository = eventRepository;
        }


        [HttpGet]
        [Route("GetAllCompanies")]
        public async Task<ActionResult> GetAllCompaniesAsync()
        {
            try
            {
                var results = await _companyRepository.getAllCompaniesAsync();
                return Ok(results);
            }




            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Service Error");
            }

        }


        [HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> AddCompany(CompanyViewModel cvm)
        {

            Random random = new Random();
        
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string firstcode = new string(Enumerable.Repeat(chars, 4)
            .Select(s => s[random.Next(s.Length)]).ToArray());

            string secondcode = new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());

            string code = firstcode + "-" + secondcode;

            var Tcompany = new Company { name = cvm.name, description = cvm.description, projectcodes = code};
            var Tcode = new ProjectCode { code = code };
            try
            {
                _companyRepository.Add(Tcompany);
                await _companyRepository.SaveChangesAsync();

                _projectCodeRepository.Add(Tcode);
                await _projectCodeRepository.SaveChangesAsync();
            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");



        }


        [HttpPut]
        [Route("UpdateCompany")]

        public async Task<ActionResult> UpdateCompany(string name, CompanyViewModel cvm)
        {



            try
            {
                var existingCompany = await _companyRepository.getCompanyAsync(name);

                if (existingCompany == null)
                {
                    return NotFound("Could not find company: " + name);
                }

                existingCompany.name = cvm.name;
                existingCompany.description = cvm.description;
                existingCompany.projectcodes = existingCompany.projectcodes;


                if (await _companyRepository.SaveChangesAsync())
                {
                    return Ok("Company updated successfully");
                }


            }




            catch (Exception)
            {
                return BadRequest("Error");
            }

            return Ok("Success");





        }



        [HttpDelete]
        [Route("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(string name)
        {
            try
            {
                var existingCompany = await _companyRepository.getCompanyAsync(name);
                if (existingCompany == null) return NotFound("not found");

                var existingCode = await _projectCodeRepository.getProjectCodeAsync(existingCompany.projectcodes);
                var existingEvent = await _eventRepository.getEventByCodeAsync(existingCompany.projectcodes);

                if (existingEvent == null) {
                    _companyRepository.Delete(existingCompany);
                    _projectCodeRepository.Delete(existingCode);
                    await _companyRepository.SaveChangesAsync();
                    return Ok(new {code = 200, message = "Company deleted successfully" });
                }
                if (existingEvent != null)
                {
                    return Ok(new { code = 400, message = "Company in use by event" });
                }
                
                

                


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("SearchCompanybyName")]

        public async Task<ActionResult<IEnumerable<Company>>> Search(string name)
        {
            try
            {
                var results = await _companyRepository.Search(name);
                if (results != null)
                {
                    return Ok(results);
                }

                return NotFound("Could not find the requested Company in the database");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }
        }

        
    }
}
