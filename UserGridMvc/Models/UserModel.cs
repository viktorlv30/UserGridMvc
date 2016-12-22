using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        
        // User surname
        public string LastName { get; set; }

        // user status - IsDeleted
        public bool Status { get; set; }

        // user phones
        public List<Phone> Phones { get; set; }

        // user emailes
        public List<Email> Emailes { get; set; }

        // user addresses
        public List<Address> Addresses { get; set; }

        // convert User to a UserModel for a view
        public UserModel ConvertUserToModel(User userToConvert)
        {
            Id = userToConvert.Id;
            Login = userToConvert.Login;
            FirstName = userToConvert.FirstName;
            LastName = userToConvert.LastName;
            Status = userToConvert.IsDeleted ? true : false;

            Phones = new List<Phone>();
            Emailes = new List<Email>();
            Addresses = new List<Address>();

            foreach (var phone in userToConvert.Phones)
            {
                Phones.Add(phone);
            }
            foreach (var email in userToConvert.Emails)
            {
                Emailes.Add(email);
            }
            foreach (var address in userToConvert.Addresses)
            {
                Addresses.Add(address);
            }

            return this;
        }
    }
}