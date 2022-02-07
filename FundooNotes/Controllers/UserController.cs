using BusinessLayer.Class;
using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;

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
        [HttpPost("login")]
        public ActionResult LogInUser(UserLogin userLogIn)
        {
            try
            {
                string result = this.userBL.LogInUser(userLogIn);
                return this.Ok(new { success = true, message = $"LogIn Successful {userLogIn.email}, data = {result}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword(string email, string password, string cPassword)
        {
            try
            {
                if (password != cPassword)
                {
                    return BadRequest(new { success = false, message = $"Paswords are not equal" });
                }
                // var identity = User.Identity as ClaimsIdentity 
                this.userBL.ResetPassword(email, password, cPassword);
                return this.Ok(new { success = true, message = $"Password changed Successfully {email}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
    
    
}
