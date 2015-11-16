namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;

    [EnableCors("*", "*", "*")]
    public class AccomodationsController : BaseController
    {
        public AccomodationsController(ITouristSiteData data) 
            : base(data)
        {
        }

        public IHttpActionResult Get()
        {
            var accomodations = this.data
                .Accomodations
                .All()
                .Select(AccomodationResponseModel.FromModel)
                .ToList();
            return this.Ok(accomodations);
        }

        public IHttpActionResult Get(int id)
        {
            var accomodation = this.data
                 .Accomodations
                 .SearchFor(a => a.AccomodationId == id)
                 .Select(AccomodationResponseModel.FromModel)
                 .FirstOrDefault();

            if (accomodation == null)
            {
                return this.NotFound();
            }

            return this.Ok(accomodation);
        }

        public IHttpActionResult Post(AccomodationRequestModel accomodation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var accomodationToAdd = new Accomodation
            {
                Name = accomodation.Name,
                Description = accomodation.Description,
                Email = accomodation.Email,
                Adress = accomodation.Adress,
                Mobile = accomodation.Mobile,
                CityId = accomodation.CityId,
            };

            this.data.Accomodations.Add(accomodationToAdd);

            return this.Ok(accomodation);
        }

        public IHttpActionResult Delete(int id)
        {
            var accomodation = this.data
                    .Accomodations
                    .SearchFor(a => a.AccomodationId == id)
                    .Select(AccomodationResponseModel.FromModel)
                    .FirstOrDefault();

            if (accomodation == null)
            {
                return this.NotFound();
            }

            this.data.Accomodations.Delete(accomodation);
            return this.Ok(accomodation);
        }

        public IHttpActionResult Put(int id, AccomodationRequestModel accomodationImput)
        {
            var accomodation = this.data
                             .Accomodations
                             .SearchFor(a => a.AccomodationId == id)
                             .Select(AccomodationResponseModel.FromModel)
                             .FirstOrDefault();

            if (accomodation == null)
            {
                return this.NotFound();
            }

            accomodation.Name = accomodationImput.Name;
            accomodation.Description = accomodationImput.Description;
            accomodation.Email = accomodationImput.Name;
            accomodation.Mobile = accomodationImput.Mobile;
            accomodation.Adress = accomodationImput.Adress;
            accomodation.CityId = accomodationImput.CityId;

            this.data.Accomodations.SaveChanges();

            return this.Ok(accomodation);
        }
    }
}
