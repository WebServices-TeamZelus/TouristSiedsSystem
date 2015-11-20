namespace TouristSitesSystem.Api.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;

    [TestClass]
    public class TouristSitesTests
    {
        private HttpMessageInvoker httpInvoker;

        [TestInitialize]
        public void Init()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional });

            var httpServer = new HttpServer(config);
            this.httpInvoker = new HttpMessageInvoker(httpServer);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetTouristSitesShouldReturnCollectionOfTouristSites()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/TouristSites"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);
                var touristSites = resultValue as List<TouristSiteResponseModel>;

                Assert.IsTrue(touristSites.Count > 0);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetTouristSiteByValidIdShouldReturnTheTouristSite()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/TouristSites/1"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);

                var touristSite = resultValue as TouristSiteResponseModel;
                Assert.AreEqual(1, touristSite.TouristSiteId);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetTouristSiteByInvalidIdShouldReturnTheTouristSite()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/TouristSites/999"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
