namespace TouristSitesSystem.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;

    public class TouristSitesController : ApiController
    {
        private TouristSitesSystemDbContext db = new TouristSitesSystemDbContext();

        public IHttpActionResult Get()
        {
            var touristSites = this.db.TouristSite.ToList();
            return this.Ok(touristSites);
        }

        public IHttpActionResult Get(int id)
        {
            List<TouristSite> touristSites = this.db.TouristSite.ToList();
            return this.Ok(touristSites.Find(a => a.TouristSiteId == id));
        }

        public IHttpActionResult Post(TouristSiteRequestModel touristSite)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dbTouristSite = new TouristSite
            {
                Name = touristSite.Name,
                Description = touristSite.Description,
                CityId = touristSite.CityId,
            };

            this.db.TouristSite.Add(dbTouristSite);
            this.db.SaveChanges();

            return this.Ok(touristSite);
        }

        public IHttpActionResult Delete(int id)
        {
            TouristSite touristSite = this.db.TouristSite.Find(id);
            if (touristSite == null)
            {
                return this.NotFound();
            }

            this.db.TouristSite.Remove(touristSite);
            this.db.SaveChanges();
            return this.Ok(touristSite);
        }

        public IHttpActionResult Put(int id, TouristSiteRequestModel touristSite)
        {
            TouristSite dbTouristSite = this.db.TouristSite.Find(id);
            if (dbTouristSite == null)
            {
                return this.NotFound();
            }

            dbTouristSite.Name = touristSite.Name;
            dbTouristSite.Description = touristSite.Description;
            dbTouristSite.CityId = touristSite.CityId;
            this.db.SaveChanges();
            return this.Ok(dbTouristSite);
        }
    }
}
