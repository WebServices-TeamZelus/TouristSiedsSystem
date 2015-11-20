namespace TouristSitesSystem.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using TouristSiteSystem.Model;

    public class TouristSiteRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}