using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace UserGridMvc.Entity.Entities
{
    public class User : IdEntity
    {

        public User()
        {
            Phones = new List<Phone>();
            Emails = new List<Email>();
            Addresses = new List<Address>();
        }

        [MinLength(1, ErrorMessage = "Too short login. Must be 1-50 chars")]
        [MaxLength(50, ErrorMessage = "Too long login. Must be 1-50 chars")]
        [Required]
        public string Login { get; set; }

        [MinLength(1, ErrorMessage = "Too short first name. Must be 1-50 chars")]
        [MaxLength(50, ErrorMessage = "Too long first name. Must be 1-50 chars")]
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //collections of users data
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }


    }
}