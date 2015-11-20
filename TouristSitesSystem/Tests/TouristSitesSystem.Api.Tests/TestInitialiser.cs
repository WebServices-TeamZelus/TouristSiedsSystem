namespace TouristSitesSystem.Api.Tests
{
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyTested.WebApi;

    [TestClass]
    public class TestInitialiser
    {
        [AssemblyInitialize]
        public static void AssemblyInitialiser(TestContext context)
        {
            var config = new HttpConfiguration();
            ////config.MapHttpAttributeRoutes();
            ////config.Routes.MapHttpRoute(
            ////    name: "DefaultApi",
            ////    routeTemplate: "api/{controller}/{id}",
            ////    defaults: new { id = RouteParameter.Optional }
            ////);

            ////MyWebApi.IsUsing(config;)

            WebApiConfig.Register(config);
            MyWebApi.IsUsing(config);
        }
    }
}
