namespace CentaurFactory.SqlServerProvider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CentaurFactory.Model;

    internal sealed class Config : DbMigrationsConfiguration<DataContext>
    {
        public Config()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}