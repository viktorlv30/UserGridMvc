using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity
{
    public class DeletableEntity
    {
        [DefaultValue(false)]
        [Required]
        public bool IsDeleted { get; set; }
    }
}