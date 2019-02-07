using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spin.Startup))]
namespace Spin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
