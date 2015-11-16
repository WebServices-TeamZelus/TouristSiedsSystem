namespace TouristSiteSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class TouristSiteData : ITouristSiteData
    {
        private ITouristSitesSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public TouristSiteData(ITouristSitesSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        //public TouristSiteData()
        //    : this(new TouristSitesSystemDbContext())
        //{
        //}

        public IRepository<Accomodation> Accomodations
        {
            get
            {
                return this.GetRepository<Accomodation>();
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IRepository<TouristSite> TouristSites
        {
            get
            {
                return this.GetRepository<TouristSite>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var type = typeof(EfGenericRepository<T>);
                this.repositories.Add(typeOfRepository, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
