namespace TouristSitesSystem.Api.App_Start
{
    using System.Data.Entity;
    using TouristSiteSystem.Data;
    using TouristSiteSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TouristSiteSystemDbContext, Configuration>());
            TouristSiteSystemDbContext.Create().Database.Initialize(true);
        }
    }
}