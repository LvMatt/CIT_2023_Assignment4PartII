using System;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class NorthwindDbContext : DbContext
    {

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
                .LogTo(Console.Out.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=admin");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetails>()
            .HasKey(od => new { od.ProductId, od.OrderId });

            modelBuilder.Entity<Category>()
                .ToTable("categories")
                .Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>()
                .Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>()
                .Property(x => x.Description).HasColumnName("description");

            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>()
                .Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>()
                .Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>()
                .Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>()
                .Property(x => x.CategoryId).HasColumnName("categoryid");

            modelBuilder.Entity<OrderDetails>()
                .ToTable("orderdetails")
                .Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>()
                .Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>()
                .Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>()
                .Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>()
                .Property(x => x.Discount).HasColumnName("discount");

            modelBuilder.Entity<Order>()
                .ToTable("orders")
                .Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShipAddress).HasColumnName("shipaddress");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShipPostalcode).HasColumnName("shippostalcode");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShipCountry).HasColumnName("shipcountry");
            modelBuilder.Entity<Order>()
                .Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>()
                .Property(x => x.RequiredDate).HasColumnName("requireddate");
            modelBuilder.Entity<Order>()
                .Property(x => x.ShippedDate).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderDate).HasColumnName("orderdate");

            // Define the relationships (you may have already done this)
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);
        }

    }
}

