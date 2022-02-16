using CommonLayer.Label;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        Task CreateLabel(int noteId, int userId, LabelModal labelModal);
        public IEnumerable<Labels> GetLabelsByNoteID(int userID, int noteID);
    }
}
