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
            /*var employeeTitle = _appDbContext.Titles.Where(zz => zz.TitlesID == */
            //List<Titles> title = from t in _appDbContext.Titles.ToList()
            //                     join e in _appDbContext.Employees.ToList()
            //                     on t.TitlesID equals e.TitlesID
            //                     select t.Description.ToList();

           // var employeetitle = _appDbContext.Titles.Select(zz => zz.Description).ToList();

            try
            {
                var results = await _employeeRepository.getAllEmployeesAsync();
                return Ok(results);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



        [HttpPost]
        [Route("AddEmployee")]

        public async Task<ActionResult> AddEmployee(EmployeeViewModel evm)
        {

            var employee = new Employees { Name = evm.Name, Surname = evm.Surname, EmailAddress = evm.Email, TitlesID = evm.TitleID };

            try
            {
                _employeeRepository.Add(employee);
                await _employeeRepository.SaveChangesAsync();

            }
            catch(Exception err)
            {
                return Ok(err); ;
            }

            return Ok("Success");
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public async Task<ActionResult> UpdateEmployee(string name, EmployeeViewModel evm)
        {

            try
            {
                var existingEmployee = await _employeeRepository.getEmployeeAsync(name);
                

                if (existingEmployee == null) return NotFound("Could not find event: " + name);

                existingEmployee.Name = evm.Name;
                existingEmployee.Surname = evm.Surname;
                existingEmployee.EmailAddress = evm.Email;
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
        public async Task<IActionResult> DeleteEmployee(string name)
        {
            try
            {
                var existingEmployee = await _employeeRepository.getEmployeeAsync(name);
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


    }
}
