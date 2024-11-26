namespace Proyecto_BazarLibreria.Migrations/LibreriaBazarDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto_BazarLibreria.Models.LibreriaBazarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations/LibreriaBazarDbContext";
        }

        protected override void Seed(Proyecto_BazarLibreria.Models.LibreriaBazarDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
