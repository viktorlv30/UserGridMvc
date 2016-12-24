using System;
using System.Collections.Generic;
using System.Linq;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.Models
{
    public class UserModel
    {
        // User ID
        public Guid Id { get; set; }

        // User login
        public string Login { get; set; }

        // User name
        public string Name { get; set; }
        
        // user status - IsDeleted
        public bool Status { get; set; }

        // user phones
        public int Phone { get; set; }

        // user emailes
        public string Email { get; set; }

        // user addresses
        public string Address { get; set; }

        // convert User to a UserModel for a view
        public UserModel ConvertUserToModel(User userToConvert)
        {
            Id = userToConvert.Id;
            Login = userToConvert.Login;
            Name = userToConvert.FirstName + " " + userToConvert.LastName;
            Status = userToConvert.IsDeleted;
            Email = userToConvert.Email?.Mail ?? "doesn't have email";

            Email = userToConvert.Email?.Mail ?? "doesn't have email";
            Phone = userToConvert.Phone?.Number ?? 0;
            Address = userToConvert.Address?.PostAddress ?? "doesn't have post address";


            return this;
        }

        public static User ConverModelToUser(UserModel modelToConvert)
        {
            var newUser = new User();

            newUser.Login = modelToConvert.Login;
            newUser.FirstName = modelToConvert.Name.Trim().Split(' ')[0];
            newUser.Email = new Email { Mail = modelToConvert.Email.Trim() };
            try
            {
                newUser.LastName = modelToConvert.Name.Trim().Split(' ')[1];
            }
            catch
            {
                newUser.LastName = null;
            }

            newUser.Address = newUser.Address ?? new Address { PostAddress = modelToConvert.Address };
            newUser.Phone = newUser.Phone ?? new Phone { Number = modelToConvert.Phone };

            return newUser;
        }

        public void SetChangedData(ref User user)
        {
            if (user.IsDeleted != this.Status)
                user.IsDeleted = this.Status;
            if (user.Login != this.Login)
                user.Login = this.Login;
            if (user.FirstName != this.Name.Trim().Split(' ')[0])
                user.FirstName = this.Name.Trim().Split(' ')[0];
            try
            {
                if (user.LastName != this.Name.Trim().Split(' ')[1])
                    user.LastName = this.Name.Trim().Split(' ')[1];
            }
            catch
            {
                user.LastName = null;
            }
            
            if (user.Phone.Number != this.Phone)
                user.Phone.Number = this.Phone;
            if (user.Email.Mail != this.Email)
                user.Email.Mail = this.Email;
            if (user.Address.PostAddress != this.Address)
                user.Address.PostAddress = this.Address;
        }
    }
}