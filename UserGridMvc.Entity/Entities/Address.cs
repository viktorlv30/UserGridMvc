using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity.Entities
{
    public class Address : DescriptionalEntity

    {
        [MaxLength(200, ErrorMessage = "Too long type string. Must be 1-200 chars")]
        public string Type { get; set; }

        public string PostAddress { get; set; }

    }
}