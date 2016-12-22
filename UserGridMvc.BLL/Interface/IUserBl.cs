using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IUserBl : ICrudBl<User>
    {

        // create new user and insert to the Db
        void CreateNewUser(User user);

        // update user and insert to the Db
        void UpdateUser(User user);

        // delete (make isdeleted = true) 
        void DeleteUser(User user);


    }
}