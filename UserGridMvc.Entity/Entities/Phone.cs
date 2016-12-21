using System.ComponentModel.DataAnnotations;

namespace UserGridMvc.Entity.Entities
{
    public class Phone : DescriptionalEntity
    {
        public string Type { get; set; }

        public int Number { get; set; }

        public virtual User User { get; set; }

    }
}