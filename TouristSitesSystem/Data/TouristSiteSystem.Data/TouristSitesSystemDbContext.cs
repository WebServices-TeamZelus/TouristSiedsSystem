namespace TouristSiteSystem.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TouristSiteSystem.Model;

    public class TouristSitesSystemDbContext : IdentityDbContext<User> , ITouristSitesSystemDbContext
    {
        public TouristSitesSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Accomodation> Accomodation { get; set; }
        
        public IDbSet<City> City { get; set; }
        
        public IDbSet<Image> Image { get; set; }
        
        public IDbSet<TouristSite> TouristSite { get; set; }
        
        public static TouristSitesSystemDbContext Create()
        {
            return new TouristSitesSystemDbContext();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
