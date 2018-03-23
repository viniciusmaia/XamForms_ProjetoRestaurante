using System.Data.Entity.Migrations;

namespace VFoodServer.DAO.Migrations
{
    public class Configuration : DbMigrationsConfiguration<VFoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}