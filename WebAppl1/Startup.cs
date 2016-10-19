using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppl1.Startup))]
namespace WebAppl1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
