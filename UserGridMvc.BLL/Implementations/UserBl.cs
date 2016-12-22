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
        public void CreateNewUser(User user)
        {
            //need to validate
            Repository.Add(user);
        }

        public void UpdateUser(User user)
        {
            //need to validate
            Repository.Update(user);
        }

        public void DeleteUser(User user)
        {
            Repository.Delete(user);
        }
    }
}