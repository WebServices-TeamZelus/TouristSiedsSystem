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
                    Url = i.Url,
                    TouristSiteName = i.TouristSite.Name
                };
            }
        }

        public int ImageId { get; set; }

        public string Url { get; set; }

        public string TouristSiteName { get; set; }
    }
}