using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademyTask.Startup))]
namespace AcademyTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
