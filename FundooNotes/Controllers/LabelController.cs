using BusinessLayer.Interface;
using CommonLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LabelController : ControllerBase
    {
        ILabelBL labelBL;
        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateLabel(LabelModal labelModel, int noteID)
        {
            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                await labelBL.CreateLabel(userID, noteID, labelModel);

                return this.Ok(new { success = true, message = "Label added successfully", response = labelModel, noteID });





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [Authorize]
        [HttpGet("GetLabelsByNoteID/{noteID}")]
        public IEnumerable GetLabelsByNoteID(int noteID)
        {
            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                return labelBL.GetLabelsByNoteID(userID, noteID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("lableName/{lableName}/{newLabelName}")]
        public IActionResult RenameLabel(string lableName, string newLabelName)
        {
            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                if (labelBL.RenameLabel(userID, lableName, newLabelName))
                {
                    return this.Ok(new { success = true, message = "Label renamed successfully", response = lableName, newLabelName });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [Authorize]
        [HttpDelete("RemoveLabel/{lableName}")]
        public IActionResult RemoveLabel(string lableName)
        {
            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                if (labelBL.RemoveLabel(userID, lableName))
                {
                    return this.Ok(new { success = true, message = "Label removed successfully", response = lableName });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet(" GetAllLabels")]
        public async Task<IActionResult> GetAllLabels()
        {

            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type== "userId").Value);

                var LabelList = new List<Labels>();
                var NoteList = new List<Note>();
                LabelList = await labelBL.GetAllLabels(userID);



                return this.Ok(new { Success = true, message = $"GetAll Labels of UserId={userID} ", data = LabelList });
                return this.Ok(new { Success = true, message = $"GetAll Notes of UserId={userID} ", data = NoteList });


            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
