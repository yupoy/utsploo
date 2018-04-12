using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UTS_PLOO_151524032_YudisthiraPoyoh.Startup))]
namespace UTS_PLOO_151524032_YudisthiraPoyoh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
