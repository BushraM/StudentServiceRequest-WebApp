using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment.Startup))]
namespace Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
