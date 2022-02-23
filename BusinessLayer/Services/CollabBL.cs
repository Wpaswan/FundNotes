using BusinessLayer.Interface;
using CommonLayer.Collab;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CollabBL : ICollabBL
    {
        ICollabRL CollabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.CollabRL = collabRL;
        }
        public async Task<List<Collab>> CreateCollab(CollabPostModel collabPost, int NotesId, int UserId)
        {
            try
            {
                return await CollabRL.CreateCollab(collabPost,NotesId,UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
