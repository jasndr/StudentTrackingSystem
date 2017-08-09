using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentTrackingSystem2.Startup))]
namespace StudentTrackingSystem2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
