using System;
using System.Linq;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Implementations
{
    public class UserBl : CrudBl<IUserRepository, User>, IUserBl
    {
        public UserBl(IUserRepository repository) : base(repository)
        {
        }

        // create new user and insert to the Db
        public User CreateNewUser(User user)
        {
            throw new NotImplementedException();
            var newUser = user;
            return newUser;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}