using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrightBoxTest.Startup))]
namespace BrightBoxTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
