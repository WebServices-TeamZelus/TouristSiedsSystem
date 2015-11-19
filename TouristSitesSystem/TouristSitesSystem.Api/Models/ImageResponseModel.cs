namespace TouristSitesSystem.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using TouristSiteSystem.Model;

    public class ImageResponseModel
    {
        public static Expression<Func<Image, ImageResponseModel>> FromModel
        {
            get
            {
                return i => new ImageResponseModel
                {
                    ImageId=i.ImageId,
                    Url = i.Url,
                    TouristSiteName = i.TouristSite.Name,
                    TouristSiteId = i.TouristSideId
                };
            }
        }

        public int ImageId { get; set; }

        public string Url { get; set; }

        public string TouristSiteName { get; set; }

        public int TouristSiteId { get; set; }
    }
}