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
    public class AccomodationsTests
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
        public void GetAccomodationsShouldReturnCollectionOfAccomodations()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Accomodations"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);
                var accomodations = resultValue as List<AccomodationResponseModel>;

                Assert.IsTrue(accomodations.Count > 0);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetAccomodationByValidIdShouldReturnTheAccomodation()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Accomodations/1"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);

                var accomodation = resultValue as AccomodationResponseModel;
                Assert.AreEqual(1, accomodation.AccomodationId);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetAccomodationByInvalidIdShouldReturnTheAccomodation()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Accomodations/999"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
        }

    }
}
