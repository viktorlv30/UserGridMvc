using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class AddressRepository : CrudRepository<Address>, IAddressRepository
    {
        public void UpdateAddress(Address address)
        {
            Update(address);
        }
    }
}