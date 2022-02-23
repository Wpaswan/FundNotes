using CommonLayer.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services 
{
    public class AddressRL:IAddressRL
    {
        FundooDBContext dbContext;
        private readonly IConfiguration configuration;
        public AddressRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

      
         public bool AddUserAddress(UserAddressPostModal userAddress, int userId)
        {
            try
            {
                var UserAddress = dbContext.UserAddresses.FirstOrDefault(x => x.userId == userId);
                UserAddress useraddress = new UserAddress();
                useraddress.userId = userId;
                useraddress.AddressId = new UserAddress().AddressId;
                useraddress.State = userAddress.State;
                useraddress.City = userAddress.City;
                useraddress.Type = userAddress.Type;
                if (useraddress.Type == "Home")
                {
                    useraddress.Type = "Home";
                }
                else if (useraddress.Type == "Work")
                {
                    useraddress.Type = "Work";
                }
                else
                {
                    useraddress.Type = "Other";
                }
               

                dbContext.UserAddresses.Add(useraddress);
                dbContext.SaveChanges();
                return default;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateUserAddress(UserAddressPostModal userAddress, int userId, int AddressId)
        {
            try
            {
                UserAddress useraddress = dbContext.UserAddresses.Where(e => e.userId == userId).FirstOrDefault();
                useraddress.Type = userAddress.Type;
                useraddress.City = userAddress.City;
                useraddress.State = userAddress.State;

                dbContext.UserAddresses.Update(useraddress);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public async Task<List<UserAddress>> GetAllAddress(int userId)
        {
            return await dbContext.UserAddresses.Where(u => u.userId == userId)

             .Include(u => u.User)
             .ToListAsync();
        }
    }
}
