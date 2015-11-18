namespace TouristSitesSystem.Api.Tests.Fakes
{
    using System;
    using Models;

    public class FakeGalleryData : ITouristSiteData
    {
        private FakeRepository<Image> images;
        private FakeRepository<Accomodation> accomodations;
        private FakeRepository<City> cities;
        private FakeRepository<TouristSites> touristSites;
        private FakeRepsitory<User> users;

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

        public IRepository<MediaFile> MediaFiles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (this.tags == null)
                {
                    this.tags = new FakeRepository<Tag>();
                }

                return this.tags;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new FakeRepository<User>();
                }

                return this.users;
            }
        }

        public int SaveChangesCallCount { get; set; }

        public void SaveChanges()
        {
            this.SaveChangesCallCount++;
        }
    }
}