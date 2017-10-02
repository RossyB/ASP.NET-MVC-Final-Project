using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStore.Web.Startup))]
namespace BookStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
