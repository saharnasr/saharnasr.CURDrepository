using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductMangement.Startup))]
namespace ProductMangement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
