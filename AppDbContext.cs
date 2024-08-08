

using Microsoft.EntityFrameworkCore;

namespace Practice2
{
    public class AppDbContext:DbContext
    {
        public DbSet <Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        //  string ConnectionString = "Server-AYSUN;Database-products;Trusted_connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AYSUN;Database=Products;Trusted_connection=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
