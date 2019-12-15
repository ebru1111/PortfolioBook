using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortfolioBook.Startup))]
namespace PortfolioBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
