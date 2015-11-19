namespace TouristSitesSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;
    using System.Web.Http.Cors;
    using System.Net.Http;
    using Providers;
    using System;

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
        public IHttpActionResult Post()
        {
            Request.Content.LoadIntoBufferAsync().Wait();
            var src = string.Empty;
            var touristSiteId = int.Parse(Request.Headers.First(x => x.Key == "touristSiteId").Value.First());

            var currentTouristSite = this.data
                .TouristSites
                .All()
                .FirstOrDefault(x => x.TouristSiteId == touristSiteId);

            Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(new MultipartMemoryStreamProvider()).ContinueWith((task) =>
            {
                MultipartMemoryStreamProvider provider = task.Result;

                foreach (HttpContent content in provider.Contents)
                {
                    var bytesContent = content.ReadAsByteArrayAsync().Result;

                    var myDropboxProvider = new DropboxProvider();


                    var path = "/" + Guid.NewGuid().ToString() + ".jpg";
                    src = myDropboxProvider.UploadFile(bytesContent, path);

                    var imageToAdd = new Image
                    {
                        Url = src,
                        Extension = "jpg",
                        Description = path,
                        TouristSideId = touristSiteId,
                        UserId = "8bdc9e17-3dd2-4d26-bd74-fef01ef41da6"
                    };

                    imageToAdd.TouristSite = currentTouristSite;

                    this.data.Images.Add(imageToAdd);
                    data.SaveChanges();
                }
            });

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