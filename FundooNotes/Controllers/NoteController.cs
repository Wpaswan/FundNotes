using BusinessLayer.Interface;
using CommonLayer.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        FundooDBContext fundooDBContext;
        INoteBL NoteBL;

        public NoteController(INoteBL NoteBL, FundooDBContext fundooDB, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.NoteBL = NoteBL;
            this.fundooDBContext = fundooDB;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        [Authorize]
        [HttpPost("createnote")]
        public async Task<ActionResult> CreateNotes(NotePostModel notePostModel)
        {
            try
            {

                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);

                await this.NoteBL.CreateNotes(userid, notePostModel);

                return this.Ok(new { success = true, message = $"Note Created Sucessfully " });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateNotes/{noteID}")]

        public IActionResult UpdateNotes(int noteID, NotePostModel notesModel)
        {
            try
            {
                if (NoteBL.UpdateNotes(noteID, notesModel))
                {
                    return this.Ok(new { Success = true, message = "Notes updated successfully", response = notesModel, noteID });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note with given ID not found" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        // [Authorize]
        [HttpGet("getAllNoteusingRedis")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var cacheKey = "NoteList";
                string serializedNoteList;
                var noteList = new List<Note>();
                var redisnoteList = await distributedCache.GetAsync(cacheKey);
                if (redisnoteList != null)
                {
                    serializedNoteList = Encoding.UTF8.GetString(redisnoteList);
                    noteList = JsonConvert.DeserializeObject<List<Note>>(serializedNoteList);
                }
                else
                {
                    noteList = await NoteBL.GetAllNotes();
                    serializedNoteList = JsonConvert.SerializeObject(noteList);
                    redisnoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                }
                return this.Ok(noteList);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("Delete/{noteID}")]
        public IActionResult DeleteNote(int noteID)
        {
            try
            {
                if (NoteBL.DeleteNote(noteID))
                {
                    return this.Ok(new { Success = true, message = "Notes deleted successfully" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes with given ID not found" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("changeColor/{noteID}/{color}")]
        public async Task<IActionResult> changeColor(int noteID, string color)
        {
            try
            {
                List<Note> note = await NoteBL.changeColor(noteID, color);
                if (note!=null)
                {
                    return this.Ok(new { Success = true, message = "Color changed successfully", data = note });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes with given ID not found" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        //[HttpPut("{noteID}/{Isarchieve}")]
        [HttpPut("ArchiveNote/{noteID}")]
        public async Task<IActionResult> IsArchieve(int noteID)
        {
            try
            {
                await NoteBL.ArchieveNote(noteID);


                return this.Ok(new { Success = true, message = $"NoteArchieve successfull for {noteID}" });




            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut(" IsTrash/{noteID}")]
        public async Task<IActionResult> IsTrash(int noteID)
        {
            try
            {
                await NoteBL.TrashNote(noteID);


                return this.Ok(new { Success = true, message = $"NoteTrash successfull for {noteID}" });




            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Authorize]
        [HttpPut("IsPin/{noteID}")]

        public async Task<IActionResult> IsPin(int noteID)
        {
            try
            {
                await NoteBL.IsPin(noteID);


                return this.Ok(new { Success = true, message = $"NoteTrash successfull for {noteID}" });




            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
