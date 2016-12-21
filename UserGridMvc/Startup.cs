using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserGridMvc.Startup))]
namespace UserGridMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
