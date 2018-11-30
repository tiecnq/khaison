using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KhaiSon.Startup))]
namespace KhaiSon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
