using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeReviewMVC_API.Startup))]
namespace CollegeReviewMVC_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
