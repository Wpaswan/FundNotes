using CommonLayer.Note;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        Task CreateNotes(int userId, NotePostModel notePost);
    }
}
