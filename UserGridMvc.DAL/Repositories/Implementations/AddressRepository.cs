using System;
using System.Linq;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class AddressRepository : CrudRepository<Address>, IAddressRepository
    {
        //public void AddAddressToUser(Guid userId, Guid addressId)
        //{
        //    var address = GetById(addressId);
        //    address.User = ContextDb.Users.FirstOrDefault(u => u.Id == userId);
        //    Update(address); ;
        //}

        //public void DeleteAddress(Guid userId, Guid addressId)
        //{
        //    var address = GetById(addressId);
        //    if (userId == address.User.Id)
        //        Delete(address);
        //}

        public void UpdateAddress(Address address)
        {
            Update(address);
        }
    }
}