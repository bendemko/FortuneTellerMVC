using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fortune_teller_mvc.Startup))]
namespace Fortune_teller_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
