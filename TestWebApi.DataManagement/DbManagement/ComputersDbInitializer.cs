using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.DbManagement
{
    public static class ComputersDbInitializer
    {
        public static void Initialize(ComputersDbContext context)
        {
            context.Database.EnsureCreated();

            // Si la base contient déjà des données on ne fait rien 
            if (context.Ordinateurs.Any() || context.Magasins.Any()) return;

            var ordinateurs = new Ordinateur[]
            {
                new Ordinateur{ Brand = "Asus", Name = "Tuf Gaming 15", Price = 1200 },
                new Ordinateur { Brand = "Acer", Name = "Swift 3", Price=650 }
            };
            foreach (var ordinateur in ordinateurs)
            {
                context.Ordinateurs.Add(ordinateur);
            }
            context.SaveChanges();

            var magasins = new Magasin[]
            {
                new Magasin{ Name = "LDLC", Location = "Lyon Vaise" },
                new Magasin{ Name = "Auchan", Location = "Dardilly" }
            };
            foreach (var magasin in magasins)
            {
                context.Magasins.Add(magasin);
            }
            context.SaveChanges();

            context.Stocks.Add(new Stock { IsDispo = true, MagasinId = context.Magasins.FirstOrDefault().Id, OrdinateurId = context.Ordinateurs.FirstOrDefault().Id });
            context.SaveChanges();
        }
    }
}
