namespace TouristSiteSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TouristSiteSystem.Model;

    public interface ITouristSiteSystemDbContext
    {
        IDbSet<Accomodation> Accomodation { get; set; }

        IDbSet<City> City { get; set; }

        IDbSet<Image> Image { get; set; }

        IDbSet<TouristSite> TouristSite { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
