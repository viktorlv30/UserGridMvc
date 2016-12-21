namespace UserGridMvc.Entity.Entities
{
    public class Address : DescriptionalEntity
    {
        public string Type { get; set; }

        public int PostAddress { get; set; }

        public virtual User User { get; set; }
    }
}