using BusinessLayer.Interface;
using CommonLayer.Label;
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
        
    }
}
