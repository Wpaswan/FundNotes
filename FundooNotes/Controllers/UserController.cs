using BusinessLayer.Class;
using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        FundooDBContext fundooDBContext;
        IUserBL userBL;
        public UserController(IUserBL userBL, FundooDBContext fundooDB)
        {
            this.userBL = userBL;
            this.fundooDBContext = fundooDB;

        }
        //[Authorize]
        [HttpPost("register")]
        public ActionResult registerUser(UserPostModal userPostModel)
        {
            try
            {
                this.userBL.RegisterUser(userPostModel);
                return this.Ok(new { success = true, message = $"Registration Successful{userPostModel.email}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpPost("login")]
        public ActionResult LogInUser(UserLogin userLogIn)
        {
            try
            {
                string result = this.userBL.LogInUser(userLogIn);
                if (result!=null)
                    return this.Ok(new { success = true, message = $"LogIn Successful {userLogIn.email}, data = {result}" });
                else
                    return this.BadRequest(new { Success = false, message = "Invalid Username and Password" });
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword(string password, string cPassword)
        {
            try
            {
                if (password != cPassword)
                {
                    return BadRequest(new { success = false, message = $"Paswords are not same" });
                }
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.Where(p => p.Type ==  @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, password, cPassword);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
                    }
                }
                return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("forgettpassword")]
        public ActionResult ForgetPassword(string email)
        {

            try
            {
                this.userBL.ForgetPassword(email);

                return Ok(new { message = "Token sent succesfully.Please check your email for password reset" });






            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet("getallusers")]
        public ActionResult GetAllUsers()
        {
            try
            {
                var result = this.userBL.GetAllUsers();
                return this.Ok(new { success = true, message = $"Below are the User data", data = result });
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }    }
