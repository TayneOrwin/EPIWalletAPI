using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;


namespace EPIWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //Add These
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicatonSettings _appSettings;
        private readonly IApplicationUserRepository _applicationuserRepository;
        private readonly IActiveLoginRepository _activeloginRepository;

        private readonly IConfiguration _configuration;


        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            IOptions<ApplicatonSettings> appSettings,
            IApplicationUserRepository applicationuserRepository,
            IActiveLoginRepository activeLoginRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            _applicationuserRepository = applicationuserRepository;
            _activeloginRepository = activeLoginRepository;
            _configuration = configuration;
            
        }
        //

        [HttpPost]
        [Route("Register")]
        //POST : /api/User/Register
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {

        
            var checkUser = await _userManager.FindByEmailAsync(model.Email);
            if (checkUser != null)
            {
                return Ok(new { code = 401, message = "User Already Exists !!!!!" });
            }
            else
            {
                var applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    AccessRoleID= model.accessRole,
                    EmployeeID = model.employeeID

                };

                try
                {
                    var result = await _userManager.CreateAsync(applicationUser, model.Password);
                    if (result.Succeeded)
                    {
                    

                        if (applicationUser.AccessRoleID==1)
                        {
                            return Ok(new { code = 201, message = "Employee Registered Succesfully" });
                        }


                        if (applicationUser.AccessRoleID == 2)
                        {
                            return Ok(new { code = 201, message = "Manager Registered Succesfully" });
                        }

                        if (applicationUser.AccessRoleID == 3)
                        {
                            return Ok(new { code = 201, message = "Creditor Registered Succesfully" });
                        }
                        if (applicationUser.AccessRoleID == 4)
                        {
                            return Ok(new { code = 201, message = "Administrator Registered Succesfully" });
                        }


                        else
                        {
                            return Ok(new { code = 404, message = "Register was succesful, Role Not Assigned" });
                        }






                    }
                    else
                    {
                        return Ok(new { code = 401, message = "Unable To Register User" });
                    }
                }
                catch (Exception ex)
                {

                    return Ok(new { code = 401, message = ex.ToString() });
                }
            }

        }
            [HttpPost]
        [Route("Login")]
        //POST : /api/User/Login
        public  async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            var PasswordCheck = await _userManager.CheckPasswordAsync(user, model.Password);

          
            if (PasswordCheck != false)
            {
                var appUser = await _applicationuserRepository.getUserAsync(user.Email);

                var activeLogin = new ActiveLogin { date = DateTime.Now, ApplicationUserID = appUser.Id };


                _activeloginRepository.Add(activeLogin);
                await _activeloginRepository.SaveChangesAsync();
            }

            
            
            try
            {

                if (user != null && PasswordCheck != false)
                {
                    
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {

                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                        


                };
                    
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    

                    if (user.AccessRoleID == 1)
                    {
                        return Ok(new { code = 200, token = token,message="Employee Access Granted" });

                    }


                    if (user.AccessRoleID == 2)
                    {
                        return Ok(new { code = 201, token = token, message="Manager Access Granted" });
                    }

                    if (user.AccessRoleID == 3)
                    {
                        return Ok(new { code = 202, token = token, message = "Creditor Access Granted" });
                    }

                    if (user.AccessRoleID == 4)
                    {
                        return Ok(new { code = 203, token = token, message = "Admin Access Granted" });
                    }


                    else
                    {
                        return Ok(new { code = 204, token = token, message = "Permission Level Not Asssigned" });
                    }






                }
                else
                {
                    var ErrorMessage = "";

                    if(user == null)
                    {
                        ErrorMessage = "unable to Find User";
                    }
                    if (PasswordCheck == false)
                    {
                        ErrorMessage = "unable to Match User Info";
                    }
                    return Ok( new { code = 401 , message = ErrorMessage});
                }
            }
            catch (Exception ex)
            {
                return Ok( new { code = 401 , message = ex });
            }

            

        }

        [HttpGet]
        [Route("GetEmployeeId")]
        public async Task<IActionResult> GetEmployeeId(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var results = user.EmployeeID;

            return Ok(results);
        }



        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword(ApplicationUserViewModel avm)
        {

            var User = await _userManager.FindByEmailAsync(avm.UserName);
            var PasswordCheck = await _userManager.CheckPasswordAsync(User, avm.CurrentPassword);
            

            static bool ValidatePassword(string pass)
            {
                int validConditions = 0;
                foreach (char c in pass)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        validConditions++;
                        break;
                    }
                }
                foreach (char c in pass)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions == 0) return false;
                foreach (char c in pass)
                {
                    if (c >= '0' && c <= '9')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions != 3 || pass.Length < 8) return false;
                
                return true;
            }
            try
            {


                if (PasswordCheck != false && User != null && ValidatePassword(avm.NewPassword) == true)
                {
                    await _userManager.ChangePasswordAsync(User, avm.CurrentPassword, avm.NewPassword);
                    return Ok(new { code = 200, message = "Password Updated Successfully" });
                }
                else 
                {
                    var ErrorMessage = "";

                    if (User == null)
                    {
                        ErrorMessage = "unable to Find User";
                        return Ok(new { code = 401, message = ErrorMessage });
                    }
                    else if (PasswordCheck == false)
                    {
                        ErrorMessage = "Password Incorrect";
                        return Ok(new { code = 401, message = ErrorMessage });
                    }
                    else if (ValidatePassword(avm.NewPassword) == false)
                    {
                        ErrorMessage = "Password Incorrect Format";
                        return Ok(new { code = 402, message = ErrorMessage });
                    }
                        return Ok();
                   
                    

                }
            }

            

            catch (Exception)
            {
                return BadRequest("Error");
            }



        }


        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ApplicationUserViewModel avm)
        {

            var User = await _userManager.FindByEmailAsync(avm.UserName);


            static bool ValidatePassword(string pass)
            {
                int validConditions = 0;
                foreach (char c in pass)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        validConditions++;
                        break;
                    }
                }
                foreach (char c in pass)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions == 0) return false;
                foreach (char c in pass)
                {
                    if (c >= '0' && c <= '9')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions != 3 || pass.Length < 8) return false;

                return true;
            }

            try
            {

                if (User != null && ValidatePassword(avm.NewPassword) == true && avm.NewPassword == avm.ConfirmPassword && avm.NewPassword != null)
                {


                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);
                    var passwordReset = Url.Action("ResetPassword", "Account", new { email = avm.UserName, token = token }, Request.Scheme);
                    await _userManager.ResetPasswordAsync(User, token, avm.NewPassword);

                    return Ok(new { code = 200, message = "Password Reset Successfully" });
                }
                else
                {
                    var ErrorMessage = "";

                    if (User == null)
                    {
                        ErrorMessage = "unable to Find User";
                        return Ok(new { code = 401, message = ErrorMessage });
                    }
                    
                    else if (ValidatePassword(avm.NewPassword) == false)
                    {
                        ErrorMessage = "Password Incorrect Format";
                        return Ok(new { code = 402, message = ErrorMessage });
                    }
                    else if (avm.NewPassword != avm.ConfirmPassword)
                    {
                        ErrorMessage = "Passwords dont match";
                        return Ok(new { code = 403, message = ErrorMessage });
                    }
                    else if (avm.NewPassword == null)
                    {
                        ErrorMessage = "Please fill out all fields";
                        return Ok(new { code = 405, message = ErrorMessage });
                    }
                    return Ok();



                }
            }
            catch
            {
                return BadRequest("Unsuccessful");
            }
            
                
                
           

        }


        [HttpGet]
        [Route("UpdateAccessRoleAndOrEmail")]

        public object UpdateAccessRoleAndOrEmail(int empid, int accid, string email)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sql = "update ApplicationUsers Set AccessRoleID = " + accid + ",  UserName = '" + email + "',  Email = '" + email + "' where EmployeeID = " + empid + "";

            SqlCommand cmd = new SqlCommand(sql, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return Ok("Success");

        }

        [HttpGet]
        [Route("getEmailStoredProcedure")]

        public object getEmailStoredProcedure(int id)
        {
            var list = new List<Email>();
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("GetEmailParameter", connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            connection.Open();
           var rdr = cmd.ExecuteReader();

           while (rdr.Read())
            {




                var res = new Email
                {
                    email = (string)rdr["Email"]
                };

            list.Add(res);
               // return Ok(rdr["Email"]);
            }

            //return Ok(rdr["Email"]);

            return list;


        }



        }
    }
