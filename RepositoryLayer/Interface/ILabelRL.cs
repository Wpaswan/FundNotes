using CommonLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        Task CreateLabel(int noteId, int userId, LabelModal labelModal);
        public IEnumerable<Labels> GetLabelsByNoteID(int userID,int noteID);
        public bool RenameLabel(int userID, string oldLabelName, string labelName);
        public bool RemoveLabel(int userID, string labelName);
        Task<List<LabelResponse>> GetAllLabels(int userId);
    }
}
