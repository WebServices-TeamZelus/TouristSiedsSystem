namespace TouristSitesSystem.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using TouristSiteSystem.Model;

    public class AccomodationResponseModel
    {
        public static Expression<Func<Accomodation, AccomodationResponseModel>> FromModel
        {
            get
            {
                return a => new AccomodationResponseModel
                {
                    AccomodationId=a.AccomodationId,
                    Name = a.Name,
                    Description = a.Description,
                    CityId = a.CityId,
                    Adress = a.Adress,
                    Email = a.Email,
                    Mobile = a.Mobile
                };
            }
        }

        public int AccomodationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string Mobile { get; set; }

        public int CityId { get; set; }
    }
}