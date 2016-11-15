using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(alfabet.Startup))]
namespace alfabet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
