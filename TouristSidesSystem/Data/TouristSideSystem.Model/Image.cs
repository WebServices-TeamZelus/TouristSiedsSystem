namespace TouristSiteSystem.Model
{
       using System.ComponentModel.DataAnnotations;

    public class Image
    {
 
        public int ImageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Url { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(10)]
        public string Extension { get; set; }

        [Required]
        public int TouristSideId { get; set; }

        public virtual TouristSite TouristSite { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
