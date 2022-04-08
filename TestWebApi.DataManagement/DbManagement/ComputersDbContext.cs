using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.DbManagement
{
    // Pour continuer, voir https://docs.microsoft.com/fr-fr/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
    // Il faudra voir comment ajouter l'injection de dependances
    public class ComputersDbContext : DbContext
    {
        public ComputersDbContext(DbContextOptions<ComputersDbContext> options) : base(options)
        {
        }

        public DbSet<Ordinateur> Ordinateurs { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ordinateur>().ToTable("Ordinateur");
            builder.Entity<Magasin>().ToTable("Magasin");
            builder.Entity<Stock>().ToTable("Stock");
        }
    }
}
