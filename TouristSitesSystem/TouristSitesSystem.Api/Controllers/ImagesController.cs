namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using TouristSiteSystem.Model;

    public class ImagesController : BaseController
    {
        public IHttpActionResult Get()
        {
            var images = this.data
                .Images
                .All()
                .Select(ImageResponseModel.FromModel)
                .ToList();

            return this.Ok(images);
        }

        public IHttpActionResult Get(int id)
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

            return this.Ok();
        }
    }
}
