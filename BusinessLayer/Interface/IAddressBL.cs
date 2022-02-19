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
        public Task AddAddress(int userId, UserAddressPostModal userAddressPostModal);
        public Task UpdateAddress(int userId, UserAddressPostModal userAddressPost);
        Task<List<UserAddress>> GetAllAddress(int userId);
        public Task DeleteAddress(int userId);

    }
}
