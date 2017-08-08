using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentTrackingSystem.Startup))]
namespace StudentTrackingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
