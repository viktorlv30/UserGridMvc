namespace UserGridMvc.Entity.Entities
{
    public class Email : DescriptionalEntity
    {
        public string Type { get; set; }

        public int Mail { get; set; }

        public virtual User User { get; set; }
    }
}