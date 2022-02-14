using BusinessLayer.Interface;
using CommonLayer.Note;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL:INoteBL
    {
        
            INoteRL noteRL;
            public NoteBL(INoteRL noteRL)
            {
                this.noteRL = noteRL;
            }

            public async Task CreateNotes(int userId, NotePostModel notePost)
            {
                try
                {
                    await noteRL.CreateNotes(userId, notePost);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        public bool UpdateNotes(int noteID, NotePostModel notesModel)
        {
            try
            {
                if (noteRL.UpdateNotes(noteID, notesModel))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }
