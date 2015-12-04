using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escola.Startup))]
namespace Escola
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
