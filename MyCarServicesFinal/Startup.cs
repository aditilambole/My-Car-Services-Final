using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCarServicesFinal.Startup))]
namespace MyCarServicesFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
