using System;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Implementations
{
    public class AddressBl : CrudBl<IAddressRepository, Address>, IAddressBl
    {
        public AddressBl(IAddressRepository repository) : base(repository)
        {
        }

        public void AddAddressToUser(Guid userId, Guid addressId)
        {
            //need to validate
            //Repository.AddAddressToUser(userId, addressId);
        }

        public void DeleteAddress(Guid userId, Guid addressId)
        {
            //Repository.DeleteAddress(userId, addressId);
        }

        public void UpdateAddress(Address address)
        {
            //need to vaidate
            Repository.UpdateAddress(address);
        }
    }
}