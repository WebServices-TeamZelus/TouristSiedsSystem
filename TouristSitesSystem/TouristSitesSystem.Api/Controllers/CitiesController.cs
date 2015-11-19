namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models;
    using TouristSiteSystem.Data;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class CitiesController : BaseController
    {
        public CitiesController(ITouristSiteData data)
            : base(data)
        {
        }

        public CitiesController()
            : this(new TouristSiteData(new TouristSitesSystemDbContext()))
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var cities = this.data
                .Cities
                .All()
                .Select(CityResponseModel.FromModel)
                .ToList();

            return this.Ok(cities);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var city = this.data
                .Cities
                .SearchFor(c => c.CityId == id)
                .Select(CityResponseModel.FromModel)
                .FirstOrDefault();

            if (city == null)
            {
                return this.NotFound();
            }

            return this.Ok(city);
        }

        [HttpGet]
        public IHttpActionResult Search(string name)
        {
            var city = this.data
                .Cities
                .SearchFor(c => c.Name == name)
                .Select(CityResponseModel.FromModel)
                .FirstOrDefault();

            if (city == null)
            {
                return this.NotFound();
            }

            return this.Ok(city);
        }
    }
}
