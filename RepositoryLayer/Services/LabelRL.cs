using CommonLayer.Label;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
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


                Labels labels = new Labels();
                labels.userId=userId;
                labels.NoteID=noteId;
                labels.LabelID=new Labels().LabelID;
                labels.LabelName=labelModal.LabelName;
                dbContext.Labels.Add(labels);
                await dbContext.SaveChangesAsync();

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

    }
}