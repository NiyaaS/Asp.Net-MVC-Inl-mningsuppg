namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.ModelDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Models.ModelDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
             context.Categories.AddOrUpdate(x => x.Id,
             new Models.Category { Id = 1, Name = "Livs-Medel" },
             new Models.Category { Id = 2, Name = "Elektronik" },
             new Models.Category { Id = 3, Name = "Kläder" },
             new Models.Category { Id = 4, Name = "Djur" },
             new Models.Category { Id = 5, Name = "Fordon" }

             );
            context.Products.AddOrUpdate(x => x.Id,
               new Models.Product { Id = 1, Category_id = 1, Name = "Bröd", Description = "mychet gott beröd", Price = 10 },
               new Models.Product { Id = 2, Category_id = 1, Name = "Mjölk", Description = "mychet gott beröd", Price = 15 },
               new Models.Product { Id = 3, Category_id = 1, Name = "Ägg", Description = "mychet gott beröd", Price = 35 },
               new Models.Product { Id = 4, Category_id = 1, Name = "Fisk", Description = "mychet gott beröd", Price = 129 },
               new Models.Product { Id = 5, Category_id = 1, Name = "Kött", Description = "mychet gott beröd", Price = 300 },

               new Models.Product { Id = 6, Category_id = 2, Name = "Mobil", Description = "mychet gott beröd", Price = 1000 },
               new Models.Product { Id = 7, Category_id = 2, Name = "Dator", Description = "mychet gott beröd", Price = 2000 },
               new Models.Product { Id = 8, Category_id = 2, Name = "Laddare", Description = "mychet gott beröd", Price = 50 },
               new Models.Product { Id = 9, Category_id = 2, Name = "Hörlurar", Description = "mychet gott beröd", Price = 10000 },

               new Models.Product { Id = 10, Category_id = 3, Name = "Jeans", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 11, Category_id = 3, Name = "Tröja", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 12, Category_id = 3, Name = "Strumpor", Description = "mychet gott beröd", Price = 100 },

               new Models.Product { Id = 13, Category_id = 4, Name = "Katt", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 14, Category_id = 4, Name = "Hund", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 15, Category_id = 4, Name = "Häst", Description = "mychet gott beröd", Price = 100 },

               new Models.Product { Id = 16, Category_id = 5, Name = "Bil", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 17, Category_id = 5, Name = "Cykel", Description = "mychet gott beröd", Price = 100 },
               new Models.Product { Id = 18, Category_id = 5, Name = "MC", Description = "mychet gott beröd", Price = 100 }
            );
        }
    }
}
