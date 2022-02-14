using BusinessLayer.Interface;
using CommonLayer.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController : Controller
    {
        FundooDBContext fundooDBContext;
        INoteRL NoteBL;

        public NoteController(INoteBL NoteBL, FundooDBContext fundooDB)
        {
            this.NoteBL = (INoteRL)NoteBL;
            this.fundooDBContext = fundooDB;
        }

        [Authorize]
        [HttpPost("createnote")]
        public async Task<ActionResult> CreateNotes(NotePostModel notePostModel)
        {
            try
            {
                var Userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userid = Int32.Parse(Userid.Value);

                await this.NoteBL.CreateNotes(userid, notePostModel);

                return this.Ok(new { success = true, message = $"Note Created Sucessfully " });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
