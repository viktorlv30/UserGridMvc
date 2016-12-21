using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace UserGridMvc.Entity.Entities
{
    public class User : DeletableEntity
    {

        public User()
        {
            Phones = new List<Phone>();
            Emails = new List<Phone>();
            Addresses = new List<Phone>();
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
        public virtual ICollection<Phone> Emails { get; set; }
        public virtual ICollection<Phone> Addresses { get; set; }


    }
}