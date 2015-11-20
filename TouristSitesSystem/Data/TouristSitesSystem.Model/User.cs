namespace TouristSiteSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
   
    public class User : IdentityUser
    {
        private ICollection<TouristSite> touristSites;

        private ICollection<Image> images;

        public User()
        {
            this.touristSites = new HashSet<TouristSite>();
            this.images = new HashSet<Image>();
        }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        public virtual ICollection<TouristSite> TouristSites
        {
            get { return this.touristSites; }
            set { this.touristSites = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            ////Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            //// Add custom user claims here
            return userIdentity;
        }
    }
}
