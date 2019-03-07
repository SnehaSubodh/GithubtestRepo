using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleRentalAgency.WebUI.Startup))]
namespace VehicleRentalAgency.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
