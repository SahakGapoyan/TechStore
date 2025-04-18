using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data.Entity;

namespace TechStore.Data.DbContext
{
    public class TechStoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TechStoreDbContext(DbContextOptions<TechStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; } = default;
        public DbSet<Model> Models { get; set; } = default;
        public DbSet<Category> Categories { get; set; } = default;
        public DbSet<Color> Colors { get; set; } = default;
        public DbSet<Laptop> Laptops { get; set; } = default;
        public DbSet<Memory> Memories { get; set; } = default;
        public DbSet<OS> OSs { get; set; } = default;
        public DbSet<Ram> Rams { get; set; } = default;
        public DbSet<Product> Products { get; set; } = default;
        public DbSet<Review> Reviews { get; set; } = default;
        public DbSet<SmartPhone> SmartPhones { get; set; } = default;
        public DbSet<Tv> Tvs { get; set; } = default;
        public DbSet<User> Users { get; set; } = default;
        public DbSet<CartItem> CartItems { get; set; } = default;
        public DbSet<Order> Orders { get; set; } = default;
        public DbSet<OrderItem> OrderItems { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartPhone>().ToTable("SmartPhones");
            modelBuilder.Entity<Laptop>().ToTable("Laptops");
            modelBuilder.Entity<Tv>().ToTable("Tvs");
            //one to many User-Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            //one to many OrderItem-Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId);

            //one to many Category-Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            //one to many Barnd-Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);

            //one to many Model-Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Model)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.ModelId);

            //one to many Product-CartItem
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(c => c.ProductId);

            //one to many User-CartItem
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserId);

            //one to many Product-OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId);


            //one to many Color-Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Color)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.ColorId);

            //one to many Ram-SmartPhone
            modelBuilder.Entity<SmartPhone>()
                .HasOne(s => s.Ram)
                .WithMany(r => r.SmartPhones)
                .HasForeignKey(s => s.RamId);

            //one to many Ram-Laptop
            modelBuilder.Entity<Laptop>()
                .HasOne(l => l.Ram)
                .WithMany(r => r.Laptops)
                .HasForeignKey(l => l.RamId);

            //one to many OS-SmartPhone
            modelBuilder.Entity<SmartPhone>()
                .HasOne(s => s.OS)
                .WithMany(os => os.SmartPhones)
                .HasForeignKey(s => s.OSId);

            //one to many OS-Laptop
            modelBuilder.Entity<Laptop>()
               .HasOne(l => l.OS)
               .WithMany(os => os.Laptops)
               .HasForeignKey(l => l.OSId);

            //one to many OS-Laptop
            modelBuilder.Entity<Laptop>()
               .HasOne(l => l.Memory)
               .WithMany(m => m.Laptops)
               .HasForeignKey(l => l.MemoryId);

            //one to many OS-Laptop
            modelBuilder.Entity<SmartPhone>()
               .HasOne(s => s.Memory)
               .WithMany(m => m.SmartPhones)
               .HasForeignKey(s => s.MemoryId);

            //config for decimal
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItem>()
                .Property(o => o.CurrentPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItem>()
                .Property(o => o.SubTotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(o => o.Price)
                .HasPrecision(18, 2);
        }
    }
}
