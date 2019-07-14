using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobProject.Startup))]
namespace JobProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
