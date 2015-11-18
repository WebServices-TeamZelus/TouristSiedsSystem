namespace TouristSitesSystem.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TouristSiteSystem.Data;

    public class FakeRepository<T> : IRepository<T> where T : class
    {
        IList<T> entities = new List<T>();

        public void Add(T entity)
        {
            this.entities.Add(entity);
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        public T Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            this.entities.Add(entity);
        }

        public void Detach(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] == id)
                {
                    return entities[i];
                }
            }
            return entities[0];
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
