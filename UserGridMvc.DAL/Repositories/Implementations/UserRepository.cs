using System;
using System.Collections.Generic;
using System.Linq;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public IEnumerable<Phone> GetAllPhonesByUser(Guid userId)
        {
            return ContextDb.Phones.Where(p => p.User.Id == userId);
        }

        public IEnumerable<Address> GetAllAddressesByUser(Guid userId)
        {
            return ContextDb.Addresses.Where(p => p.User.Id == userId);
        }

        public IEnumerable<Email> GetAllEmailsByUser(Guid userId)
        {
            return ContextDb.Emails.Where(p => p.User.Id == userId);
        }
    }
}