using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVC.Statup))]

namespace WebMVC
{
    public class Statup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}