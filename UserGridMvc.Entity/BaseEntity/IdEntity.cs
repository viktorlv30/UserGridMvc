using System;
using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity
{
    public class IdEntity : DeletableEntity, IEntity
    {
        public IdEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }


    }
}