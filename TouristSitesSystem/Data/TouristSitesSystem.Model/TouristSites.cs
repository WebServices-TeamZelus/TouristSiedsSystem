namespace TouristSiteSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TouristSite
    {
        private ICollection<User> user;

        private ICollection<Image> images;

        public TouristSite()
        {
            this.user = new HashSet<User>();
            this.images = new HashSet<Image>();
        }

        public int TouristSiteId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<User> User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
