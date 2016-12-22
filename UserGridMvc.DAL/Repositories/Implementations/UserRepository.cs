using System;
using System.Collections.Generic;
using System.Linq;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        //public User GetUserById(Guid id)
        //{
        //    return ContextDb.Users.FirstOrDefault(u => u.Id == id);
        //}

        //public void UpdateUserById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteUserById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddUser(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}