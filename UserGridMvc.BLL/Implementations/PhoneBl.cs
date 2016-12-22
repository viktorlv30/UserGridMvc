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
            //Repository;
        }

        public void DeletePhone(Guid userId, Guid phoneId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> GetAllPhonesByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePhone(Guid phoneId)
        {
            throw new NotImplementedException();
        }
    }
}