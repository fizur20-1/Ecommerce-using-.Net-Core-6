using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{  


    public class EcommeceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)

            {
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-B8UM566\\MSSQLSERVER2022;Database=ecommerce23Db;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
        public EcommeceDbContext()
        {
          
        }
        public EcommeceDbContext (DbContextOptions<EcommeceDbContext> options) : base(options)
        {

        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }
}
