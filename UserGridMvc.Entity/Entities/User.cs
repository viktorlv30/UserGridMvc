using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Web.ModelBinding;

namespace UserGridMvc.Entity.Entities
{
    public class User : IdEntity
    {

        public User()
        {
            
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
        public virtual Phone Phone { get; set; }
        public virtual Email Email { get; set; }
        public virtual Address Address { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var errors = new List<ValidationResult>();
        //    if (val1 < 0)
        //    {
        //        errors.Add(new ValidationResult("val1 can't be negative", new List<string> { "val2" }));
        //    }
        //    if (val2 < 0)
        //    {
        //        errors.Add(new ValidationResult("val2 can't be negative", new List<string> { "val2" }));
        //    }
        //    return errors;
        //}

    }
    

}