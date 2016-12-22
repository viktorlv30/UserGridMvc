using System;
using System.Collections.Generic;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IPhoneRepository : ICrudRepository<Phone>
    {
        void AddPhoneToUser(Guid userId, Guid phoneId);
        
        void DeletePhone(Guid userId, Guid phoneId);
        
        void UpdatePhone(Phone phone);

    }
}