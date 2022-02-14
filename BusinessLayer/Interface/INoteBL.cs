using CommonLayer.Note;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        Task CreateNotes(int userId, NotePostModel notePost);
    }
}
