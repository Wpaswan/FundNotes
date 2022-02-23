using BusinessLayer.Interface;
using CommonLayer.Collab;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("Collab")]
    public class CollabController : ControllerBase
    {
        ICollabBL collabBL;
        public CollabController(ICollabBL collabBL)
        {
            this.collabBL = collabBL;
        }
        [Authorize]
        [HttpPost("CreateCollab")]
        public async Task<ActionResult> CreateCollab(CollabPostModel collabPostModel, int noteID)
        {
            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                await collabBL.CreateCollab(collabPostModel, noteID,userID);

                return this.Ok(new { success = true, message = "Collab added successfully", response =  noteID });





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [Authorize]
        [HttpDelete("deleteCollabs/{CollabId}")]
        public async Task<IActionResult> RemoveCollabs(int CollabId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);

                await collabBL.RemoveCollab(CollabId, UserId);

                return this.Ok(new { success = true, message = "Collabartion deleted successfully", response = CollabId });

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpGet("getAllCollabs")]
        public async Task<IActionResult> GetAllCollabs()
        {

            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);

                var CollabrationList = new List<Collab>();
                CollabrationList = await collabBL.GetAllCollabs(userID);

                return this.Ok(new { Success = true, message = $"GetAll Collabs of Userid={userID} ", data = CollabrationList });



            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}


    

