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
            ContextKey = "WebApp.Models.ModelDB";
        }

        protected override void Seed(WebApp.Models.ModelDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(x => x.Id,
                new Models.Category {Id = 1, Name = "Frukt" },
                new Models.Category { Id = 2, Name = "Chips" },
                new Models.Category { Id = 3, Name = "Dricka" },
                new Models.Category { Id = 4, Name = "Grönsaker" },
                new Models.Category { Id = 5, Name = "Övrigt" }
            );
            context.Products.AddOrUpdate(x => x.Id,
                new Models.Product {Id = 10, Name ="Äpple", Price = 10, Description ="Röda äpplen med smak av caramel", Category_id = 1},
                new Models.Product { Id = 54, Name = "Banan", Price = 13, Description = "30Cm långa bananer från Norge", Category_id = 1},
                new Models.Product { Id = 63, Name = "Orange", Price = 6, Description = "Orange fast ändå inte orange:a", Category_id = 1},
                new Models.Product { Id = 98, Name = "Melon", Price = 665, Description = "Förstår att du tycker det är dyrt men så är de", Category_id = 1},

                new Models.Product { Id = 32, Name = "Dill", Price = 21, Description = "Estrellas dill med smak av dill", Category_id = 2},
                new Models.Product { Id = 41, Name = "Grill", Price = 19, Description = "Olw's Grill med smak av coca cola", Category_id = 2},
                new Models.Product { Id = 22, Name = "Krill", Price = 400, Description = "Ingen aning vad krill smakar fråga en val", Category_id = 2},

                new Models.Product { Id = 1, Name = "Öl", Price = 40, Description = "Skapad av en fantastisk person som är bosatt i kattegatt", Category_id =3 },
                new Models.Product { Id = 99, Name = "Vatten", Price = 0, Description = "Ja de är vatten, Ja de är gratis", Category_id =3 },
                new Models.Product { Id = 33, Name = "Juice", Price = 7, Description = "Inte vilken Juice som helst, man blir stark.", Category_id = 3 },
                new Models.Product { Id = 55, Name = "Mjölk", Price = 10, Description = "Från ko av giraff", Category_id = 3 },

                new Models.Product { Id = 76, Name = "Tomat", Price = 50, Description = "Odlad i Santiago Arizona", Category_id = 4},
                new Models.Product { Id = 34, Name = "Gurka", Price = 66, Description = "En fantastisk god gurka med smak av gurka", Category_id = 4},
                new Models.Product { Id = 22, Name = "Ost", Price = 2, Description = "Inte vanlig ost en Grönsaks-ost såklart", Category_id = 4},
                new Models.Product { Id = 77, Name = "Brocollie", Price = 89, Description = "Man kan tro att den är grön men den är gul", Category_id = 4},
                new Models.Product { Id = 88, Name = "Champinjon", Price = 99, Description = "Made in China", Category_id = 4},

                new Models.Product {Id = 1001, Name ="Random Product", Price = 20, Description ="Kommer inte på något bra att skriva här", Category_id = 5 }

            );
        }
    }
}
