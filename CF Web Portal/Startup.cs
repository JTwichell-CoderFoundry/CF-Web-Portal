using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CF_Web_Portal.Startup))]
namespace CF_Web_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
