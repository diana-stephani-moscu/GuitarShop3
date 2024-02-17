using GuitarShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Guitar> Guitar { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guitar>().ToTable("Guitar");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<CartItem>().ToTable("CartItem");
            base.OnModelCreating(modelBuilder);
        }
    }
}
