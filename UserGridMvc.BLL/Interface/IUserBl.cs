using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IUserBl : ICrudBl<User>
    {

        // create new user and insert to the Db
        User CreateNewUser(User user);

        // update user and insert to the Db
        User UpdateUser(User user);

        // delete (make isdeleted = true) 
        User DeleteUser(User user);


    }
}