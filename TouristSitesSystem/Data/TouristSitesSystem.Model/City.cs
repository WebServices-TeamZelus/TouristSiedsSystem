namespace TouristSiteSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        private ICollection<TouristSite> touristSite;

        private ICollection<Accomodation> accomodation;

        public City()
        {
            this.touristSite = new HashSet<TouristSite>();
            this.accomodation = new HashSet<Accomodation>();
        }

        public int CityId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TouristSite> TouristSites
        {
            get { return this.touristSite; }
            set { this.touristSite = value; }
        }

        public virtual ICollection<Accomodation> Accomodation
        {
            get { return this.accomodation; }
            set { this.accomodation = value; }
        }
    }
}
