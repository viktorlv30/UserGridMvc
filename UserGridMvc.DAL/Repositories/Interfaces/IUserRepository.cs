using System;
using System.Collections.Generic;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        //List<User> GetAllUsers();

        //User GetUserById(Guid id);

        //void UpdateUserById(Guid id);

        //void DeleteUserById(Guid id);

        //void AddUser(User user);
    }
}