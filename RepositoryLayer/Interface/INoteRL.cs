
using CommonLayer.Note;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {                   
        Task CreateNotes(int userId, NotePostModel notePost);
        public bool UpdateNotes(int noteID, NotePostModel notesPost);
        Task<List<Note>> GetAllNotes(int userId);
        public bool DeleteNote(int notesID);
        Task<List<Note>> changeColor(int noteID, string color);
        Task  ArchieveNote(int noteId);
        Task TrashNote(int noteId);
        Task IsPin(int noteId); 


    }
}
