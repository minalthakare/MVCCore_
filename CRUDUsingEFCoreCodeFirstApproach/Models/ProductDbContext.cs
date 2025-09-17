using CRUDUsingEFCoreCodeFirstApproach.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCoreCodeFirstApproach.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) 
            : base( options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public  DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().
                HasData(new Category() { Id = 1, Name = "Electronics", Rating = 4 });

            modelBuilder.Entity<Category>().
                HasData(new Category() { Id = 2, Name = "Mobiles", Rating = 5 });
        }

    }
}
