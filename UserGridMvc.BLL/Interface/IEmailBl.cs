using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IEmailBl : ICrudBl<Email>
    {
        // adding a email to a user
        void AddEmailToUser(Guid userId, Guid emailId);

        // delete email from a user
        void DeleteEmail(Guid userId, Guid emailId);

        // update email 
        void UpdateEmail(Email email);

    }
}