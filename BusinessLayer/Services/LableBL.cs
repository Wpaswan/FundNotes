using BusinessLayer.Interface;
using CommonLayer.Label;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LableBL : ILabelBL
    {
        ILabelRL labelRL;
        public LableBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public async Task CreateLabel(int noteId, int userId, LabelModal labelModal)
        {
            try
            {
                await labelRL.CreateLabel(noteId, userId, labelModal);
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
                return labelRL.GetLabelsByNoteID(userID, noteID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RenameLabel(int userID, string oldLabelName, string labelName)
        {
            try
            {
                return labelRL.RenameLabel(userID, oldLabelName, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RemoveLabel(int userID, string labelName)
        {
            try
            {
                return labelRL.RemoveLabel(userID, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }

      

       

        public Task<List<LabelResponse>> GetAllLabels(int userId)
        {
            try
            {
                return labelRL.GetAllLabels(userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
         
        
    
}
