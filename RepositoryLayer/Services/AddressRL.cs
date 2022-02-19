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

        public async Task AddAddress(int userId, UserAddressPostModal userAddressPostModal)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(x => x.userId==userId);
                UserAddress userAddress = new UserAddress();
                userAddress.userId = userId;
               userAddress.AddressId=new UserAddress().AddressId;
                userAddress.Address = userAddressPostModal.Address;
                userAddress.State = userAddressPostModal.State;
                userAddress.City = userAddressPostModal.City;
                dbContext.UserAddresses.Add(userAddress);
                await dbContext.SaveChangesAsync();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateAddress(int userId, UserAddressPostModal userAddressPost)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(x => x.userId==userId);
                UserAddress userAddress = new UserAddress();
                userAddress.userId = userId;
                userAddress.AddressId=new UserAddress().AddressId;
                userAddress.Address = userAddressPost.Address;
                userAddress.State = userAddressPost.State;
                userAddress.City = userAddressPost.City;
                dbContext.UserAddresses.Add(userAddress);
                await dbContext.SaveChangesAsync();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
