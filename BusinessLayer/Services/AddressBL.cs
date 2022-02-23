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
       

        public bool AddUserAddress(UserAddressPostModal userAddress, int userId)
        {
            try
            {
                return addressRL.AddUserAddress(userAddress, userId);

            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<List<UserAddress>> GetAllAddress(int userId)
        {
            try{
                return await addressRL.GetAllAddress(userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            }

        public async Task UpdateUserAddress(UserAddressPostModal userAddress, int userId, int AddressId)
        {
            try
            {
                await addressRL.UpdateUserAddress(userAddress,AddressId, AddressId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
