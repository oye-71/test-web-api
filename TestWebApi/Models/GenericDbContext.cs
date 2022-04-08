using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }

        public DbSet<GenericItem> GenericItems { get; set; }
    }
}
