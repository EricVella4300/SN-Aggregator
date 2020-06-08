using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SN_Aggregator_Web_App.Startup))]
namespace SN_Aggregator_Web_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
