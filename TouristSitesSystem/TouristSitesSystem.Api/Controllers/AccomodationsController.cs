namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;
    using System.Collections.Generic;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class AccomodationsController : ApiController
    {
        private TouristSitesSystemDbContext db = new TouristSitesSystemDbContext();

        public IHttpActionResult Get()
        {
            var accomodations = this.db.Accomodation.ToList();
            return this.Ok(accomodations);
        }

        public IHttpActionResult Get(int id)
        {
            List<Accomodation> accomodations = this.db.Accomodation.ToList();
            return this.Ok(accomodations.Find(a => a.AccomodationId == id));
        }

        public IHttpActionResult Post(AccomodationRequestModel accomodation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dbAccomodation = new Accomodation
            {
                Name = accomodation.Name,
                Description = accomodation.Description,
                Email = accomodation.Email,
                Adress = accomodation.Adress,
                Mobile = accomodation.Mobile,
                CityId = accomodation.CityId,
            };

            this.db.Accomodation.Add(dbAccomodation);
            this.db.SaveChanges();

            return this.Ok(accomodation);
        }

        public IHttpActionResult Delete(int id)
        {
            Accomodation accomodation = this.db.Accomodation.Find(id);
            if (accomodation == null)
            {
                return this.NotFound();
            }

            this.db.Accomodation.Remove(accomodation);
            this.db.SaveChanges();
            return this.Ok(accomodation);
        }

        public IHttpActionResult Put(int id, AccomodationRequestModel accomodation)
        {
            Accomodation dbAccomodation = this.db.Accomodation.Find(id);
            if (dbAccomodation == null)
            {
                return this.NotFound();
            }

            dbAccomodation.Name = accomodation.Name;
            dbAccomodation.Description = accomodation.Description;
            dbAccomodation.Email = accomodation.Name;
            dbAccomodation.Mobile = accomodation.Mobile;
            dbAccomodation.Adress = accomodation.Adress;
            dbAccomodation.CityId = accomodation.CityId;
            this.db.SaveChanges();
            return this.Ok(dbAccomodation);
        }
    }
}
