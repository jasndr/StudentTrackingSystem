using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentTrackingSystem3.Startup))]
namespace StudentTrackingSystem3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
