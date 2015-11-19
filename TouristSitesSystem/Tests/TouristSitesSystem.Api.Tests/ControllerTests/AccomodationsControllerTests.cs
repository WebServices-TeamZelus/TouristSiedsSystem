namespace TouristSitesSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using TouristSiteSystem.Model;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Models;

    [TestClass]
    public class AccomodationsControllerTests
    {
        [TestMethod]
        public void GetAllShouldReturnZeroAccomodationsWhenEmpty()
        {
            var data = new FakeTouristSitesData();
            var controller = new AccomodationsController(data);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<AccomodationResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(0, okResult.Content.Count);
        }

        [TestMethod]
        public void GetShouldReturnOneAccomodationWhenThereIsOne()
        {
            var data = new FakeTouristSitesData();
            data.Accomodations.Add(new Accomodation());
            var controller = new AccomodationsController(data);
            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<AccomodationResponseModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(1, okResult.Content.Count);
        }
    }
}
