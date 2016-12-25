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

        public bool IsSuchUserExist(User newUser)
        {
            var findUser = Repository.Get(u =>
                u.Login == newUser.Login &&
                u.FirstName == newUser.FirstName &&
                u.LastName == newUser.LastName &&
                u.Phone.Number == newUser.Phone.Number &&
                u.Phone.Type == newUser.Phone.Type &&
                u.Email.Mail == newUser.Email.Mail &&
                u.Email.Type == newUser.Email.Type &&
                u.Address.PostAddress == newUser.Address.PostAddress &&
                u.Address.Type == newUser.Address.Type &&
                u.IsDeleted == newUser.IsDeleted).FirstOrDefault();
            return findUser != null;
        }
    }
}