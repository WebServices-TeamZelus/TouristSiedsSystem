namespace TouristSiteSystem.Data
{
    using TouristSiteSystem.Model;

    public interface ITouristSiteData
    {
        IRepository<Accomodation> Accomodations { get; }

        IRepository<City> Cities { get; }

        IRepository<Image> Images { get; }

        IRepository<TouristSite> TouristSites { get; }

        int SaveChanges();
    }
}
