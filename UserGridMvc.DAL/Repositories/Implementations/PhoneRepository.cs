using System;
using System.Collections.Generic;
using System.Linq;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class PhoneRepository : CrudRepository<Phone>, IPhoneRepository
    {
        public void AddPhoneToUser(Guid userId, Guid phoneId)
        {
            var phone = GetById(phoneId);
            phone.User = ContextDb.Users.FirstOrDefault(u => u.Id == userId);
            Update(phone); ;
        }

        public void DeletePhone(Guid userId, Guid phoneId)
        {
            var phone = GetById(phoneId);
            if(userId == phone.User.Id)
                Delete(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            Update(phone);
        }
    }
}