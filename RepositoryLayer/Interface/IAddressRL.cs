using CommonLayer.Address;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        public Task AddAddress(int userId, UserAddressPostModal userAddressPostModal);
        public Task UpdateAddress(int userId, UserAddressPostModal userAddressPost);
        Task<List<UserAddress>> GetAllAddress(int userId);

    }
}
