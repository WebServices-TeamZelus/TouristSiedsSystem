namespace TouristSitesSystem.Api.Tests.RouteTests
{
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Controllers;
    using Models;

    using MyTested.WebApi;

    [TestClass]
    public class AccomodationsControllerTests
    {
        [TestMethod]
        [TestCategory("Route")]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Accomodations")
                .To<AccomodationsController>(c => c.Get());
        }

        [TestMethod]
        [TestCategory("Route")]
        public void GetByIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Accomodations/1")
                .To<AccomodationsController>(c => c.GetById(1));
        }

        [TestMethod]
        [TestCategory("Route")]
        public void PostWithValidModelStateShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Accomodations")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"": ""Test name"", ""Adress"": ""Test address"", ""CityId"": 1}")
                .To<AccomodationsController>(c => c.Post(new AccomodationRequestModel
                {
                    Name = "Test name",
                    Adress = "Test address",
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
                .ShouldMap("api/Accomodations")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Adress"": ""Test address"", ""CityId"": 1}")
                .To<AccomodationsController>(c => c.Post(new AccomodationRequestModel
                {
                    Adress = "Test address",
                    CityId = 1
                }))
                .ToInvalidModelState();
        }

        [TestMethod]
        [TestCategory("Route")]
        public void PostWithoutAddressShouldBeResolvedToInvalidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Accomodations")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"": ""Test name"", ""CityId"": 1}")
                .To<AccomodationsController>(c => c.Post(new AccomodationRequestModel
                {
                    Name = "Test name",
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
                .ShouldMap("api/Accomodations")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"": ""Test name"", ""Adress"": ""Test address""}")
                .To<AccomodationsController>(c => c.Post(new AccomodationRequestModel
                {
                    Name = "Test name",
                    Adress = "Test address"
                }))
                .ToInvalidModelState();
        }
    }
}
