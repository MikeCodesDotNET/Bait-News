using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DailyFail.Backend.Startup))]

namespace DailyFail.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}