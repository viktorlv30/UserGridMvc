using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGridMvc.Entity.Entities
{
    public class Address : DescriptionalEntity

    {
        [MaxLength(200, ErrorMessage = "Too long type string. Must be 1-200 chars")]
        public string Type { get; set; }

        [Required]
        public string PostAddress { get; set; }

        //[Required]
        //public virtual User User { get; set; }
    }
}