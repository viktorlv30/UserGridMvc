using System;
using System.Collections.Generic;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        IEnumerable<Phone> GetAllPhonesByUser(Guid userId);
        IEnumerable<Address> GetAllAddressesByUser(Guid userId);
        IEnumerable<Email> GetAllEmailsByUser(Guid userId);
        
    }
}