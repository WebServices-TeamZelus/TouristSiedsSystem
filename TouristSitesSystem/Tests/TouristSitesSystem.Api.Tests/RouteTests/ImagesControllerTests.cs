namespace TouristSitesSystem.Api.Tests.RouteTests
{
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Controllers;
    using Models;

    using MyTested.WebApi;

    [TestClass]
    public class ImagesControllerTests
    {
        [TestMethod]
        [TestCategory("Route")]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Images")
                .To<ImagesController>(c => c.Get());
        }

        [TestMethod]
        [TestCategory("Route")]
        public void GetByIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Images/1")
                .To<ImagesController>(c => c.GetById(1));
        }

        //[TestMethod]
        //[TestCategory("Route")]
        //public void PostWithValidModelStateShouldMapCorrectly()
        //{
        //    MyWebApi
        //        .Routes()
        //        .ShouldMap("api/Images")
        //        .WithHttpMethod(HttpMethod.Post)
        //        .WithJsonContent(@"{""Url"": ""www.testurl.com"", ""Description"": ""Test description"", ""TouristSideId"": 1, ""UserId"": ""myUserId""}")
        //        .To<ImagesController>(c => c.Post(new ImageRequestModel
        //        {
        //            Url = "www.testurl.com",
        //            Description = "Test description",
        //            TouristSideId = 1,
        //            UserId = "myUserId"
        //        }))
        //        .ToValidModelState();
        //}

        //[TestMethod]
        //[TestCategory("Route")]
        //public void PostWithoutUrlShouldBeResolvedToInvalidModelState()
        //{
        //    MyWebApi
        //        .Routes()
        //        .ShouldMap("api/Images")
        //        .WithHttpMethod(HttpMethod.Post)
        //        .WithJsonContent(@"{""Description"": ""Test description"", ""TouristSideId"": 1, ""UserId"": ""myUserId""}")
        //        .To<ImagesController>(c => c.Post(new ImageRequestModel
        //        {
        //            Description = "Test description",
        //            TouristSideId = 1,
        //            UserId = "myUserId"
        //        }))
        //        .ToInvalidModelState();
        //}

        //[TestMethod]
        //[TestCategory("Route")]
        //public void PostWithoutTouristSiteIdShouldBeResolvedToInvalidModelState()
        //{
        //    MyWebApi
        //        .Routes()
        //        .ShouldMap("api/Images")
        //        .WithHttpMethod(HttpMethod.Post)
        //        .WithJsonContent(@"{""Url"": ""www.testurl.com"", ""Description"": ""Test description"", ""UserId"": ""myUserId""}")
        //        .To<ImagesController>(c => c.Post(new ImageRequestModel
        //        {
        //            Url = "www.testurl.com",
        //            Description = "Test description",
        //            UserId = "myUserId"
        //        }))
        //        .ToInvalidModelState();
        //}

        //[TestMethod]
        //[TestCategory("Route")]
        //public void PostWithoutUserIdShouldBeResolvedToInvalidModelState()
        //{
        //    MyWebApi
        //        .Routes()
        //        .ShouldMap("api/Images")
        //        .WithHttpMethod(HttpMethod.Post)
        //        .WithJsonContent(@"{""Url"": ""www.testurl.com"", ""Description"": ""Test description"", ""TouristSideId"": 1}")
        //        .To<ImagesController>(c => c.Post(new ImageRequestModel
        //        {
        //            Url = "www.testurl.com",
        //            Description = "Test description",
        //            TouristSideId = 1,
        //        }))
        //        .ToInvalidModelState();
        //}
    }
}
