namespace TouristSiteSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Web.Security;

    public sealed class Configuration : DbMigrationsConfiguration<TouristSitesSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TouristSitesSystemDbContext context)
        {
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            if (Membership.GetUser("testUser") == null)
            {
                Membership.CreateUser("testUser", "somePass");
                Roles.AddUsersToRole(new[] { "testUser" }, "Admin");
            }
        }
    }
}
