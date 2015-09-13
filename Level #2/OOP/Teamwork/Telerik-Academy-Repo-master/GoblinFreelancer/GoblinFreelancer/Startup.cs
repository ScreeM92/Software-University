using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoblinFreelancer.Startup))]
namespace GoblinFreelancer
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
