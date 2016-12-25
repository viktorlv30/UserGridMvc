using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity
{
    public class DescriptionalEntity : IdEntity
    {

        [MinLength(1, ErrorMessage = "Too short login. Must be 1-300 chars")]
        [MaxLength(300, ErrorMessage = "Too long login. Must be 1-300 chars")]
        public string Description { get; set; }
    }
}