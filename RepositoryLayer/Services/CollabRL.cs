using CommonLayer.Collab;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CollabRL:ICollabRL
    {
        FundooDBContext dbContext;

        public CollabRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Collab>> CreateCollab(CollabPostModel collabPost, int NotesId, int UserId)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(e => e.userId == UserId);
                var note = dbContext.Note.FirstOrDefault(u => u.NoteId == NotesId);
                Collab collab = new Collab();
                collab.collabEmail = collabPost.collabEmail;
                collab.NoteID = NotesId;
                collab.CollabId = new Collab().CollabId;
               
                collab.User = user;
                collab.Note = note;
                dbContext.Collab.Add(collab);
                await dbContext.SaveChangesAsync();
                return await dbContext.Collab.Where(u => u.userId == UserId)
                    .Include(u => u.Note)
                    .Include(u => u.User)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task RemoveCollab(int CollabId, int Userid)
        {
            try
            {
                Collab collabarator = await dbContext.Collab.Where(u => u.CollabId == CollabId).FirstOrDefaultAsync();
                if (collabarator != null)
                {
                    // Collabarator collabarator = new Collabarator();
                    this.dbContext.Collab.Remove(collabarator);
                    await this.dbContext.SaveChangesAsync();
                    // await dbContext.collabarators.ToListAsync();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
