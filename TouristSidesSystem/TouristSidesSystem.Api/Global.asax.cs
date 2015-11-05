namespace TouristSitesSystem.Api
{
    using System.Web.Http;
    using TouristSitesSystem.Api.App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
