using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourManagementApps.Startup))]
namespace TourManagementApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
