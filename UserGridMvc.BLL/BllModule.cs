using Autofac;
using UserGridMvc.BLL.Implementations;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Implementations;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity;

namespace UserGridMvc.BLL
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IEntity>();
            builder.RegisterType<ICrudRepository<IdEntity>>().As<CrudRepository<IdEntity>>();
            builder.RegisterType<ICrudBl<IdEntity>>().As<ICrudBl<IdEntity>>();
            builder.RegisterType<IUserRepository>().As<UserRepository>();
            builder.RegisterType<IPhoneRepository>().As<PhoneRepository>();
            builder.RegisterType<IEmailRepository>().As<EmailRepository>();
            builder.RegisterType<IAddressRepository>().As<AddressRepository>();
            builder.RegisterType<IUserBl>().As<UserBl>();
            builder.RegisterType<IPhoneBl>().As<PhoneBl>();
            builder.RegisterType<IEmailBl>().As<EmailBl>();
            builder.RegisterType<IAddressBl>().As<AddressBl>();

            base.Load(builder);
        }
    }
}
