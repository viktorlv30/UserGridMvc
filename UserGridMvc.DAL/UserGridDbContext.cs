using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL
{
    public class UserGridDbContext : DbContext
    {
        public UserGridDbContext() : base("dbConnection")
        {
            //setting Db initializer
            //Database.SetInitializer(new UserGridInitializer());
            //Database.Initialize(true);
        }

        // Context entities
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
