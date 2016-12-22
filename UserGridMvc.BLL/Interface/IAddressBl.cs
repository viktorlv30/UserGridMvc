using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IAddressBl : ICrudBl<Address>
    {
        // adding a address to a user
        void AddAddressToUser(Guid userId, Guid addressId);

        // delete address from a user
        void DeleteAddress(Guid userId, Guid addressId);

        // update address 
        void UpdateAddress(Address address);
    }
}