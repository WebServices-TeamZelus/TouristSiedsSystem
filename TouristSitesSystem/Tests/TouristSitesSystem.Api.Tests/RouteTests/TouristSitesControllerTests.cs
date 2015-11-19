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
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites")
                .To<TouristSitesController>(c => c.Get());
        }

        [TestMethod]
        public void GetWithIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/TouristSites/1")
                .To<TouristSitesController>(c => c.Get(1));
        }

        [TestMethod]
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
