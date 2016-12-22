using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IEmailRepository : ICrudRepository<Email>
    {
        void AddEmailToUser(Guid userId, Guid emailId);

        void DeleteEmail(Guid userId, Guid emailId);

        void UpdateEmail(Email email);
    }
}