using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Forums.Startup))]
namespace MVC_Forums
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
