using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IAddressRepository : ICrudRepository<Address>
    {
        void AddAddressToUser(Guid userId, Guid addressId);

        void DeleteAddress(Guid userId, Guid addressId);

        void UpdateAddress(Address address);
    }
}