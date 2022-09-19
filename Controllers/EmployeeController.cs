using EPIWalletAPI.Models;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetAllEmployees")]

        public async Task<ActionResult> GetAllEmployeesAsync()
        {
 

            try
            {
                var results = await _employeeRepository.getAllEmployeesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetTitles")]

        public async Task<IActionResult> GetTitles()
        {
            try
            {
                var results = await _employeeRepository.getTitlesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



        [HttpPost]
        [Route("AddEmployee")]

        public async Task<ActionResult> AddEmployee(EmployeeViewModel evm)
        {

            var employee = new Employees { Name = evm.Name, Surname = evm.Surname, TitlesID = evm.TitleID };

            try
            {
                _employeeRepository.Add(employee);
                await _employeeRepository.SaveChangesAsync();

            }
            catch (Exception err)
            {
                return Ok(err); ;
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public async Task<ActionResult> UpdateEmployee(int id, EmployeeViewModel evm)
        {

            try
            {
                var existingEmployee = await _employeeRepository.getEmployeeAsync(id);


                if (existingEmployee == null) return NotFound("Could not find employee");

                existingEmployee.Name = evm.Name;
                existingEmployee.Surname = evm.Surname;
                existingEmployee.TitlesID = evm.TitleID;


                if (await _employeeRepository.SaveChangesAsync())
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
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var existingEmployee = await _employeeRepository.getEmployeeAsync(id);
                if (existingEmployee == null) return NotFound();


                _employeeRepository.Delete(existingEmployee);

                if (await _employeeRepository.SaveChangesAsync())
                {
                    return Ok("event deleted successfully");
                }


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("SearchEmployee")]
        public async Task<ActionResult<IEnumerable<Employees>>> Search(string name) // IEnumerable used for iterating through collection of a type??
        {
            try
            {
                var result = await _employeeRepository.Search(name);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Could not find the requested employee");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("GetTitleByID")]

        public async Task<IActionResult> GetTitleByID(int id)
        {

            var results = await _employeeRepository.getTitleByID(id);

            try
            {
                return Ok(results);
            }
            catch(Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet]
        [Route("GetIdByTitle")]

        public async Task<IActionResult> GetIdByTitle(string title)
        {

            var results = await _employeeRepository.getIdByTitle(title);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet]
        [Route("GetEmployeeById")]

        public async Task<IActionResult> GetEmployeeById(int id)
        {

            var results = await _employeeRepository.GetEmployeeByID(id);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet]
        [Route("GetNameById")]

        public async Task<IActionResult> GetNameById(int id)
        {

            var results = await _employeeRepository.GetEmployeeByID(id);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }









        [HttpGet]
        [Route("GetIdByFullname")]

        public async Task<IActionResult> GetIdByFullname(string name, string surname)
        {

            var results = await _employeeRepository.getIdByFullname(name,surname);

            try
            {
                return Ok(results);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }






    }
    }
