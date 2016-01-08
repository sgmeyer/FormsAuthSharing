using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharingCookies.Startup))]
namespace SharingCookies
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
