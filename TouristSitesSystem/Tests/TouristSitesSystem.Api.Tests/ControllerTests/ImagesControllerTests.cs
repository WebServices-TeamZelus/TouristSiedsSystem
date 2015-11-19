namespace TouristSitesSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using TouristSiteSystem.Model;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Models;

    [TestClass]
    public class ImagesControllerTests
    {
        [TestMethod]
        public void GetAllShouldReturnZeroImagesWhenEmpty()
        {
            var data = new FakeTouristSitesData();
            var controller = new ImagesController(data);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<ImageResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(0, okResult.Content.Count);
        }
    }
}
