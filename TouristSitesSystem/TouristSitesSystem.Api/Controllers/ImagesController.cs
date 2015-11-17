namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class ImagesController : BaseController
    {
        public ImagesController(ITouristSiteData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var images = this.data
                .Images
                .All()
                .Select(ImageResponseModel.FromModel)
                .ToList();

            return this.Ok(images);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var image = this.data
                .Images
                .SearchFor(i => i.ImageId == id)
                .Select(ImageResponseModel.FromModel)
                .FirstOrDefault();

            if (image == null)
            {
                return this.NotFound();
            }

            return this.Ok(image);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(ImageRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var imageToAdd = new Image
            {
                Url = model.Url,
                Description = model.Description,
                TouristSideId = model.TouristSideId,
                UserId = model.UserId
            };

            this.data.Images.Add(imageToAdd);
            data.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var image = this.data
                    .Images
                    .SearchFor(i => i.ImageId == id)
                    .Select(ImageResponseModel.FromModel)
                    .FirstOrDefault();

            if (image == null)
            {
                return this.NotFound();
            }

            this.data.Images.Delete(image.ImageId);
            data.SaveChanges();

            return this.Ok(image);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Put(int id, ImageRequestModel model)
        {
            var image = this.data
                             .Images
                             .All()
                             .Where(i => i.ImageId == id)
                             .FirstOrDefault();

            if (image == null)
            {
                return this.NotFound();
            }

            image.Url = model.Url;
            image.Description = model.Description;
            image.TouristSideId = model.TouristSideId;

            this.data.Images.Update(image);
            data.SaveChanges();

            return this.Ok(image);
        }
    }
}