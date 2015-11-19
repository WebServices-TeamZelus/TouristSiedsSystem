namespace TouristSitesSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Models;
    using TouristSiteSystem.Model;

    [TestClass]
    public class CitiesControllerTests
    {
        [TestMethod]
        public void GetAllShouldReturnZeroCitiesWhenEmpty()
        {
            var data = new FakeTouristSitesData();
            var controller = new CitiesController(data);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<CityResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(0, okResult.Content.Count);
        }

        [TestMethod]
        public void GetShouldReturnOneCityWhenThereIsOne()
        {
            var data = new FakeTouristSitesData();
            data.Cities.Add(new City());
            var controller = new CitiesController(data);
            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<CityResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(1, okResult.Content.Count);
        }
    }
}
