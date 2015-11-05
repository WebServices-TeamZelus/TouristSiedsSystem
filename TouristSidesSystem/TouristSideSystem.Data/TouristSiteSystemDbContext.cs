namespace TouristSiteSystem.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TouristSiteSystem.Model;

    public class TouristSiteSystemDbContext : IdentityDbContext<User> , ITouristSiteSystemDbContext
    {
        public TouristSiteSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Accomodation> Accomodation { get; set; }
        
        public IDbSet<City> City { get; set; }
        
        public IDbSet<Image> Image { get; set; }
        
        public IDbSet<TouristSite> TouristSite { get; set; }
        
        public static TouristSiteSystemDbContext Create()
        {
            return new TouristSiteSystemDbContext();
        }
    }
}
