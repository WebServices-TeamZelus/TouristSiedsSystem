namespace TouristSitesSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Models;
    using TouristSiteSystem.Model;

    [TestClass]
    public class TouristSitesControllerTests
    {
        [TestMethod]
        [TestCategory("Controller")]
        public void GetAllShouldReturnZeroTouristSitesWhenEmpty()
        {
            var data = new FakeTouristSitesData();
            var controller = new TouristSitesController(data);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<TouristSiteResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(0, okResult.Content.Count);
        }

        [TestMethod]
        [TestCategory("Controller")]
        public void GetShouldReturnOneTouristSiteWhenThereIsOne()
        {
            var data = new FakeTouristSitesData();
            data.TouristSites.Add(new TouristSite());
            var controller = new TouristSitesController(data);
            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<TouristSiteResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(1, okResult.Content.Count);
        }
    }
}
