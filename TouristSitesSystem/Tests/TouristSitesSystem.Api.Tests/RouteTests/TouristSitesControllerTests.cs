namespace TouristSitesSystem.Api.Tests.RouteTests
{
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Controllers;
    using Models;

    using MyTested.WebApi;


    [TestClass]
    public class TouristSitesControllerTests
    {
        [TestMethod]
        [TestCategory("Route")]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites")
                .To<TouristSitesController>(c => c.Get());
        }

        [TestMethod]
        [TestCategory("Route")]
        public void GetWithIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites/1")
                .To<TouristSitesController>(c => c.Get(1));
        }

        [TestMethod]
        [TestCategory("Route")]
        public void PostWithValidModelStateShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"": ""Test name"", ""Description"": ""Test"", ""CityId"": 1}")
                .To<TouristSitesController>(c => c.Post(new TouristSiteRequestModel
                {
                    Name = "Test name",
                    Description = "Test",
                    CityId = 1
                }))
                .ToValidModelState();
        }

        [TestMethod]
        [TestCategory("Route")]
        public void PostWithoutNameShouldBeResolvedToInvalidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Description"": ""Test"", ""CityId"": 1}")
                .To<TouristSitesController>(c => c.Post(new TouristSiteRequestModel
                {
                    Description = "Test",
                    CityId = 1
                }))
                .ToInvalidModelState();
        }

        [TestMethod]
        [TestCategory("Route")]
        public void PostWithoutCityIdShouldBeResolvedToInvalidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"": ""Test name"", ""Description"": ""Test""}")
                .To<TouristSitesController>(c => c.Post(new TouristSiteRequestModel
                {
                    Name = "Test name",
                    Description = "Test",
                }))
                .ToInvalidModelState();
        }

    }
}
