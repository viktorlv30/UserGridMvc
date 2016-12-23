using System;
using System.Linq;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class EmailRepository : CrudRepository<Email>, IEmailRepository
    {
        public void AddEmailToUser(Guid userId, Guid emailId)
        {
            //var email = GetById(emailId);
            //email.User = ContextDb.Users.FirstOrDefault(u => u.Id == userId);
            //Update(email); ;
        }

        public void DeleteEmail(Guid userId, Guid emailId)
        {
            //var email = GetById(emailId);
            //if (userId == email.User.Id)
            //    Delete(email);
        }

        public void UpdateEmail(Email email)
        {
            Update(email);
        }
    }
}