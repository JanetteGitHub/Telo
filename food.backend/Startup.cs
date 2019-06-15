using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(food.backend.Startup))]
namespace food.backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
