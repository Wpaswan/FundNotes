using CommonLayer.Collab;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICollabBL
    {
        Task<List<Collab>> CreateCollab(CollabPostModel collabPost, int NotesId, int UserId);
    

    }
}
