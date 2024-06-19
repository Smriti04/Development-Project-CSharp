using Microsoft.EntityFrameworkCore;
using Sparcpoint.Data.Entities;

namespace Sparcpoint.Infrastructure
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductAttributes> Attributes { get; set; }
        public DbSet<CategoryAttributes> CategoriesAttributes { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Transaction> Transaction { get; set; }



        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(c=>c.InstanceId);
            modelBuilder.Entity<Category>().HasKey(c=>c.InstanceId);
            modelBuilder.Entity<ProductAttributes>().HasKey(c=>new {c.ProductId,c.Key});
            modelBuilder.Entity<ProductCategories>().HasKey(c=>new {c.ProductInstanceId,c.CategoryInstanceId});
            modelBuilder.Entity<CategoryAttributes>().HasKey(c=>new {c.CategoryInstanceId,c.Key});
            modelBuilder.Entity<Transaction>().HasKey(c=>c.TransactionId);


        }
    }
}