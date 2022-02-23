using CommonLayer.Address;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAddressBL
    {
        public bool AddUserAddress(UserAddressPostModal userAddress, int userId);
        public Task UpdateUserAddress(UserAddressPostModal userAddress, int userId, int AddressId);
        Task<List<UserAddress>> GetAllAddress(int userId);
    }
}
