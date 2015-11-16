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
                    Description = i.Description
                };
            }
        }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}