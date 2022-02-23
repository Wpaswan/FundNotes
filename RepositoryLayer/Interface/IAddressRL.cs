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
        public bool AddUserAddress(UserAddressPostModal userAddress, int userId);
        public  Task UpdateUserAddress(UserAddressPostModal userAddress, int userId, int AddressId);


        Task<List<UserAddress>> GetAllAddress(int userId);

    }
}
