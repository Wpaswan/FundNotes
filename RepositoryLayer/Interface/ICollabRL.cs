using CommonLayer.Collab;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICollabRL
    {
        Task<List<Collab>> CreateCollab(CollabPostModel collabPost, int NotesId, int UserId);
       
    }
}
