using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(travelapp.Startup))]
namespace travelapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
