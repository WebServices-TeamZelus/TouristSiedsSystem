namespace TouristSitesSystem.Api.Tests
{
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Model;

    class FakeTouristSitesData : ITouristSiteData
    {
        private FakeRepository<Accomodation> accomodations;
        private FakeRepository<Image> images;
        private FakeRepository<TouristSite> touristSites;
        private FakeRepository<City> cities;

        public IRepository<Accomodation> Accomodations
        {
            get
            {
                if (this.accomodations == null)
                {
                    this.accomodations = new FakeRepository<Accomodation>();
                }

                return this.accomodations;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (this.cities == null)
                {
                    this.cities = new FakeRepository<City>();
                }

                return this.cities;
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                if (this.images == null)
                {
                    this.images = new FakeRepository<Image>();
                }

                return this.images;
            }
        }

        public IRepository<TouristSite> TouristSites
        {
            get
            {
                if (this.touristSites == null)
                {
                    this.touristSites = new FakeRepository<TouristSite>();
                }

                return this.touristSites;
            }
        }

        public int SaveChangesCallCount { get; set; }

        int ITouristSiteData.SaveChanges()
        {
            return this.SaveChangesCallCount++;
        }
    }
}
