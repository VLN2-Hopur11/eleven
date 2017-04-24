using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eleven.Startup))]
namespace eleven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
