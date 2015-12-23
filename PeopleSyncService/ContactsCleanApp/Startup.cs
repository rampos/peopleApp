using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactsCleanApp.Startup))]
namespace ContactsCleanApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
