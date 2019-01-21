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
             new Models.Category { Id = 3, Name = "Kl�der" },
             new Models.Category { Id = 4, Name = "Djur" },
             new Models.Category { Id = 5, Name = "Fordon" }

             );
            context.Products.AddOrUpdate(x => x.Id,
               new Models.Product { Id = 1, Category_id = 1, Name = "Br�d", Description = "mychet gott ber�d", Price = 10 },
               new Models.Product { Id = 2, Category_id = 1, Name = "Mj�lk", Description = "mychet gott ber�d", Price = 15 },
               new Models.Product { Id = 3, Category_id = 1, Name = "�gg", Description = "mychet gott ber�d", Price = 35 },
               new Models.Product { Id = 4, Category_id = 1, Name = "Fisk", Description = "mychet gott ber�d", Price = 129 },
               new Models.Product { Id = 5, Category_id = 1, Name = "K�tt", Description = "mychet gott ber�d", Price = 300 },

               new Models.Product { Id = 6, Category_id = 2, Name = "Mobil", Description = "mychet gott ber�d", Price = 1000 },
               new Models.Product { Id = 7, Category_id = 2, Name = "Dator", Description = "mychet gott ber�d", Price = 2000 },
               new Models.Product { Id = 8, Category_id = 2, Name = "Laddare", Description = "mychet gott ber�d", Price = 50 },
               new Models.Product { Id = 9, Category_id = 2, Name = "H�rlurar", Description = "mychet gott ber�d", Price = 10000 },

               new Models.Product { Id = 10, Category_id = 3, Name = "Jeans", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 11, Category_id = 3, Name = "Tr�ja", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 12, Category_id = 3, Name = "Strumpor", Description = "mychet gott ber�d", Price = 100 },

               new Models.Product { Id = 13, Category_id = 4, Name = "Katt", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 14, Category_id = 4, Name = "Hund", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 15, Category_id = 4, Name = "H�st", Description = "mychet gott ber�d", Price = 100 },

               new Models.Product { Id = 16, Category_id = 5, Name = "Bil", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 17, Category_id = 5, Name = "Cykel", Description = "mychet gott ber�d", Price = 100 },
               new Models.Product { Id = 18, Category_id = 5, Name = "MC", Description = "mychet gott ber�d", Price = 100 }
            );
        }
    }
}
