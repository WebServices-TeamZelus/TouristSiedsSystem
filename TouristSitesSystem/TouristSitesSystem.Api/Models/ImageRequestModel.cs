namespace TouristSitesSystem.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ImageRequestModel
    {
        [Required]
        public string Url { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public int TouristSideId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}