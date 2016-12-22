using System;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Implementations
{
    public class EmailBl : CrudBl<IEmailRepository, Email>, IEmailBl
    {
        public EmailBl(IEmailRepository repository) : base(repository)
        {
        }

        public void AddEmailToUser(Guid userId, Guid emailId)
        {
            //need to validate
            Repository.AddEmailToUser(userId, emailId);
        }

        public void DeleteEmail(Guid userId, Guid emailId)
        {
            Repository.DeleteEmail(userId, emailId);
        }

        public void UpdateEmail(Email email)
        {
            //need to validate
            Repository.UpdateEmail(email);
        }
    }
}