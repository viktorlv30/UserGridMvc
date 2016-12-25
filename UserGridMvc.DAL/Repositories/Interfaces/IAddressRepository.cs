using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Interfaces
{
    public interface IAddressRepository : ICrudRepository<Address>
    {
        void UpdateAddress(Address address);
    }
}