using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautyCare.Startup))]
namespace BeautyCare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
