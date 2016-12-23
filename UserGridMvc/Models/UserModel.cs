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
            Status = userToConvert.IsDeleted ? true : false;
            Email = userToConvert.Email?.Mail ?? "doesn't have email";

            Email = userToConvert.Email?.Mail ?? "doesn't have email";
            Phone = userToConvert.Phone?.Number ?? 0;
            Address = userToConvert.Address?.PostAddress ?? "doesn't have post address";


            return this;
        }
    }
}