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
    public class CitiesTests
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
        public void GetCitiesShouldReturnCollectionOfCities()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Cities"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);
                var cities = resultValue as List<CityResponseModel>;

                Assert.IsTrue(cities.Count > 0);
            }
        }

        [TestMethod]
        public void GetCityByValidIdShouldReturnTheCity()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Cities/1"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);

                var city = resultValue as CityResponseModel;
                Assert.AreEqual(1, city.CityId);
            }
        }

        [TestMethod]
        public void GetCityByInvalidIdShouldReturnNotFound()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Cities/999"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
        }

        [TestMethod]
        public void SearchCityByValidNameShouldReturnTheCity()
        {
            using (this.httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Cities?name=Sofia"),
                    Method = HttpMethod.Get
                };

                var response = this.httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                object resultValue;
                var hasValue = response.TryGetContentValue(out resultValue);

                var city = resultValue as CityResponseModel;
                Assert.AreEqual("Sofia", city.Name);
            }
        }
    }
}
