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

     
    }
    
    
}
