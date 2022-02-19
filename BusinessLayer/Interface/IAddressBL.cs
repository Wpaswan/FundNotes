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
       
    }
}
