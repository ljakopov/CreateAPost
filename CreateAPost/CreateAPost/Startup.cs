using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreateAPost.Startup))]
namespace CreateAPost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
