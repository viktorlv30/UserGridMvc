using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity.Entities
{
    public class Email : DescriptionalEntity
    {
        [MaxLength(200, ErrorMessage = "Too long type string. Must be 1-200 chars")]
        public string Type { get; set; }

        [Required]
        public string Mail { get; set; }

   }
}