namespace TouristSitesSystem.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TouristSiteSystem.Model;

    public class TouristSiteResponseModel
    {
        public static Expression<Func<TouristSite, TouristSiteResponseModel>> FromModel
        {
            get
            {
                return t => new TouristSiteResponseModel
                {
                    TouristSiteId = t.TouristSiteId,
                    Name = t.Name,
                    Description = t.Description,
                    CityId = t.CityId,
                    Images = t.Images.Select(i => i.Url).ToList()
                };
            }
        }

        public int TouristSiteId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public List<string> Images { get; set; }
    }
}