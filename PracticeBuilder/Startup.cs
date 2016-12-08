using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeBuilder.Startup))]
namespace PracticeBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
