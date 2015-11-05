namespace TouristSiteSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Accomodation
    {
        public int AccomodationId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Adress { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
