using System;
using System.Collections.Generic;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IPhoneBl : ICrudBl<Phone>
    {
        // adding a subject to a teacher
        void AddPhoneToUser(Guid userId, Guid phoneId);

        // delete phone from a user
        void DeletePhone(Guid userId, Guid phoneId);
        
        //get all user's phones
        IEnumerable<Phone> GetAllPhonesByUser(Guid userId);
        
        // update phone 
        bool UpdatePhone(Guid phoneId);

    }
}