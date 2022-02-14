using CommonLayer.Note;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooDBContext dbContext;
        private readonly IConfiguration configuration;
        public NoteRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateNotes(int userId, NotePostModel notePost)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(x => x.userId==userId);
                Note note = new Note();

                note.NotesId=new Note().NotesId;
                note.Title=notePost.Title;
                note.Description=notePost.Description;
                note.CreatedDate=DateTime.Now;
                note.IsReminder=false;
                note.IsArchive=false;
                note.IsTrash=false;
                note.color="#fff";


                dbContext.Note.Add(note);
                await dbContext.SaveChangesAsync();



            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
