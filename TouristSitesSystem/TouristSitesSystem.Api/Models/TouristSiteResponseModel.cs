namespace TouristSitesSystem.Api.Models
{
    using System;
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
                    Name = t.Name,
                    Description = t.Description,
                    CityId=t.CityId
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }
    }
}