using CommonLayer.Note;
using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
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
                Note note=new Note();
                note.userId=userId;
                note.NoteId=new Note().NoteId;
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

        public bool UpdateNotes(int noteID, NotePostModel notesPost)
        {
            Note notes=dbContext.Note.Where(e => e.NoteId==noteID).FirstOrDefault();
            notes.Title = notesPost.Title;
            notes.Description=notesPost.Description;
            dbContext.Note.Update(notes);
            var result=dbContext.SaveChangesAsync();
            if (result!=null)
               return true;
            else
                 return false;
            
        }

        public async Task<List<Note>> GetAllNotes(int userId)
        {
            
            return await dbContext.Note.Where(u => u.userId == userId)
               
                .Include(u => u.User)
                .Include(u => u.Label)
                .Include(u => u.Collab)
                .Include(u => u.UserAddresses)
                .ToListAsync();
        }


        public bool DeleteNote(int notesID)
        {
            Note notes = dbContext.Note.Where(e => e.NoteId == notesID).FirstOrDefault();
            if (notes != null)
            {
                dbContext.Note.Remove(notes);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Note>> changeColor(int noteID, string color)
        {
            try
            {
                var note=dbContext.Note.FirstOrDefault(u=> u.NoteId==noteID);
                note.color=color;
                await dbContext.SaveChangesAsync();
                return await dbContext.Note.ToListAsync();

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task ArchieveNote(int noteId)
        {
            try
            {
                var note = dbContext.Note.FirstOrDefault(u => u.NoteId==noteId);
                note.IsArchive=true;
                await dbContext.SaveChangesAsync();
                
            }
            catch (Exception e)
            {

            }
        }

        public async Task TrashNote(int noteId)
        {
            try
            {
                var note = dbContext.Note.FirstOrDefault(u => u.NoteId==noteId);
                note.IsTrash=true;
                await dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task IsPin(int noteId)
        {
            try
            {
                var note = dbContext.Note.FirstOrDefault(u => u.NoteId==noteId);
                note.IsPin=true;
                await dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
    
}