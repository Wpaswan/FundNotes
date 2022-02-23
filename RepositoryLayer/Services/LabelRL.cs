using CommonLayer.Label;
using CommonLayer.Note;
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
    public class LabelRL : ILabelRL
    {
        FundooDBContext dbContext;
        private readonly IConfiguration configuration;
        public LabelRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateLabel(int noteId, int userId, LabelModal labelModal)
        {
            try
            {

                var user = dbContext.Users.FirstOrDefault(e => e.userId==userId);
                var note = dbContext.Note.FirstOrDefault(u => u.NoteId==noteId);
                Labels labels = new Labels
                {
                
                    Users = user,

                    notes = note
                };

               
                labels.userId=userId;
                labels.NoteID=noteId;
                labels.LabelID=new Labels().LabelID;
                labels.LabelName=labelModal.LabelName;
                dbContext.Labels.Add(labels);
                await dbContext.SaveChangesAsync();
                 await dbContext.Labels.Where(u => u.userId == userId)
                   .Include(u => u.Users)
                   .Include(u => u.notes)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Labels> GetLabelsByNoteID(int userID, int noteID)
        {
            try
            {
                var result = dbContext.Labels.Where(e => e.NoteID == noteID && e.userId == userID).ToList();
                if (result!=null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RenameLabel(int userID, string oldLabelName, string labelName)
        {
            Labels labels = new Labels();

            labels= dbContext.Labels.FirstOrDefault(e => e.userId==userID&&e.LabelName==oldLabelName);

            if (labels!=null)
            {
                labels.LabelName=labelName;
                dbContext.SaveChanges();
                return true;
            }


            return false;
        }

        public bool RemoveLabel(int userID, string labelName)
        {
            IEnumerable<Labels> labels;
            labels = dbContext.Labels.Where(e => e.userId == userID && e.LabelName == labelName).ToList();
            if (labels != null)
            {
                foreach (var label in labels)
                {
                    dbContext.Labels.Remove(label);
                }
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }



        public async Task<List<LabelResponse>> GetAllLabels(int userId)
        {
            Labels labels = new Labels();
            try
            {

                return await dbContext.Labels.Where(l => l.userId == userId)

                  .Join(dbContext.Users
                  .Join(dbContext.Note,
                    u => u.userId,
                    n => n.userId,
                    (u, n) => new NoteUserResponse
                    {
                        userId= u.userId,
                        NotesId=n.NoteId,
                        fName=u.fName,
                        lName=u.lName,
                        color=n.color,
                        RegisteredDate= n.CreatedDate,
                        Title = n.Title,
                        Description = n.Description,
                        email=u.email,

                    }),
                   l => l.notes.NoteId,
                    un => un.NotesId,
                    (l, un) => new LabelResponse
                    {
                        userId=un.userId,
                        NotesId=l.notes.NoteId,
                        Title=un.Title,
                        Description=un.Description,
                        RegisteredDate=un.RegisteredDate,
                        color=un.color,
                        fName=un.fName,
                        lName=un.lName,
                        email=un.email,
                        LabelName=l.LabelName


                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}