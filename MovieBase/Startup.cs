using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieBase.Startup))]
namespace MovieBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
