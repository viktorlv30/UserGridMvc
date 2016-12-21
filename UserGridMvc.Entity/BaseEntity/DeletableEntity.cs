namespace UserGridMvc.Entity
{
    public class DeletableEntity : IdEntity
    {
         public bool IsDeleted { get; set; }
    }
}