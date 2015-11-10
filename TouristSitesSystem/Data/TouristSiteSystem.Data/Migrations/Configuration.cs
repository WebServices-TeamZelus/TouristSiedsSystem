namespace TouristSiteSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
   public sealed class Configuration : DbMigrationsConfiguration<TouristSitesSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TouristSitesSystemDbContext context)
        {
            
        }
    }
}
