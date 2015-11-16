namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;

    [EnableCors("*", "*", "*")]
    public class TouristSitesController : BaseController
    {
        public TouristSitesController(ITouristSiteData data)
            : base(data)
        {
        }

        public IHttpActionResult Get()
        {
            var touristSites = this.data
                .TouristSites
                .All()
                .Select(TouristSiteResponseModel.FromModel)
                .ToList();

            return this.Ok(touristSites);
        }

        public IHttpActionResult Get(int id)
        {
            var touristSite = this.data
                 .TouristSites
                 .SearchFor(t => t.TouristSiteId == id)
                 .Select(TouristSiteResponseModel.FromModel)
                 .FirstOrDefault();

            if (touristSite == null)
            {
                return this.NotFound();
            }

            return this.Ok(touristSite);
        }

        public IHttpActionResult Post(TouristSiteRequestModel touristSite)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var touristSiteToAdd = new TouristSite
            {
                Name = touristSite.Name,
                Description = touristSite.Description,
                CityId = touristSite.CityId
            };

            this.data.TouristSites.Add(touristSiteToAdd);

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var touristSite = this.data
                 .TouristSites
                 .SearchFor(t => t.TouristSiteId == id)
                 .Select(TouristSiteResponseModel.FromModel)
                 .FirstOrDefault();

            if (touristSite == null)
            {
                return this.NotFound();
            }

            this.data.TouristSites.Delete(touristSite);

            return this.Ok(touristSite);
        }

        public IHttpActionResult Put(int id, TouristSiteRequestModel touristSiteImput)
        {
             var touristSite = this.data
                  .TouristSites
                  .SearchFor(t => t.TouristSiteId == id)
                  .Select(TouristSiteResponseModel.FromModel)
                  .FirstOrDefault();

            if (touristSite == null)
            {
                return this.NotFound();
            }

            touristSite.Name = touristSiteImput.Name;
            touristSite.Description = touristSiteImput.Description;
            touristSite.CityId = touristSiteImput.CityId;

            this.data.TouristSites.SaveChanges();

            return this.Ok(touristSite);
        }
    }
}
