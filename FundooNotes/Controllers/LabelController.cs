using BusinessLayer.Interface;
using CommonLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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

    }
}
