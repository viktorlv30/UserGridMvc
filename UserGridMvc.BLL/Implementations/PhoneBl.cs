using System;
using System.Collections.Generic;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Implementations
{
    public class PhoneBl : CrudBl<IPhoneRepository, Phone>, IPhoneBl
    {
        public PhoneBl(IPhoneRepository repository) : base(repository)
        {
        }

        public void AddPhoneToUser(Guid userId, Guid phoneId)
        {
            //need to validate
            Repository.AddPhoneToUser(userId, phoneId);
        }

        public void DeletePhone(Guid userId, Guid phoneId)
        {
            Repository.DeletePhone(userId, phoneId);
        }

        public void UpdatePhone(Phone phone)
        {
            //need to validate
            Repository.UpdatePhone(phone);
        }
    }
}