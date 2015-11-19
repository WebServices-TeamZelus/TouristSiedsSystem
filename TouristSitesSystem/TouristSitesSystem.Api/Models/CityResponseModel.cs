namespace TouristSitesSystem.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using TouristSiteSystem.Model;

    public class CityResponseModel
    {
        public static Expression<Func<City, CityResponseModel>> FromModel
        {
            get
            {
                return c => new CityResponseModel
                {
                    CityId = c.CityId,
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public int CityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}