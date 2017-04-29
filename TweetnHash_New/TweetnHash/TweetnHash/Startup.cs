using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TweetnHash.Startup))]
namespace TweetnHash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
