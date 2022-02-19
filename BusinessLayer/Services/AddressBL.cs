using BusinessLayer.Interface;
using CommonLayer.Address;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public async Task AddAddress(int userId, UserAddressPostModal userAddressPostModal)
        {
            try
            {
                await addressRL.AddAddress(userId, userAddressPostModal);

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
                await addressRL.UpdateAddress(userId, userAddressPost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserAddress>> GetAllAddress(int userId)
        {
            try
            {
                return await addressRL.GetAllAddress(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAddress(int userId)
        {
            try
            {
                await addressRL.DeleteAddress(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
