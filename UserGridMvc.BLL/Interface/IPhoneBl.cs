using System;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.BLL.Interface
{
    public interface IPhoneBl : ICrudBl<Phone>
    {
        // adding a phone to a user
        void AddPhoneToUser(Guid userId, Guid phoneId);

        // delete phone from a user
        void DeletePhone(Guid userId, Guid phoneId);
        
        // update phone 
        void UpdatePhone(Phone phone);

    }
}