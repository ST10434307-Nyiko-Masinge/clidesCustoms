using Microsoft.EntityFrameworkCore;
using ClidesCustoms.Models; 

namespace ClidesCustoms.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
        public DbSet<Service> Services { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<CarItem> CarItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Note: In-memory database doesn't support precision configuration
            // Decimal precision is handled at the application level

            // Configure foreign key relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany()
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //seed or inject initial data 

            modelBuilder.Entity<Service>().HasData(new Service
            {
                Id = 1,
                Name = "Oil Change",
                Description = "Complete oil change with filter",
                Price = 49.99m,
                Category = "Maintenance",
                DurationMinutes = 30,
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6_1Es3aB63u12weAWb1WgvuI2lHHsDrQgZQ&s"
            },

            new Service
            {
                Id = 2,
                Name = "Custom Paint Job",
                Description = "Professional custom paintservvice for your vehicle ",
                Price = 1499.99m,
                Category = "Custom",
                DurationMinutes = 480,
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXjbKZFE0T-8rOm2FC--JwbvN6sct6iIQBVw&s"
            },

            new Service
            {
                Id = 3,
                Name = "Brakes Replacement",
                Description = "Front Break pads worn and Brake Disks. Completed break inspection and service",
                Price = 299.99m,
                Category = "Repair",
                DurationMinutes = 120,
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQg3Ei0UYFIvSu_kS2KPhkZ7cDyZv3lZeLRhw&s"
            }
            );

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Performance air filter",
                Description = "R600 Racing line air filter and intake for improved engine performance",
                Price = 799.99m,
                Category = "Parts",
                StockQuantity = 50,
                Brand = "RacingLine",
                ImageURL = "https://www.vagcafe.com/wp-content/uploads/2014/12/IMG_4176-e1511502836662.jpg"
            },

            new Product
            {
                Id = 2,
                Name = "LED Headlight Kit ",
                Description = "LED Golf 7.5 gti headlights",
                Price = 399.99m,
                Category = "Parts",
                StockQuantity = 10,
                Brand = "OEM",
                ImageURL = "https://jabsport.co.za/wp-content/uploads/2022/12/img_1669832652185-600x354.jpg"
            },

            new Product
            {
                Id = 3,
                Name = "Bucket Seats",
                Description = "Set of 2 racing bucket seats with harnesses",
                Price = 1000.99m,
                Category = "Interior",
                StockQuantity = 5,
                Brand = "Recaro",
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1vEDF9uA3CHPSFFcc89NkTZTF8bb6xEwt-g&s"
            }
            );

            // Seed sample customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@email.com",
                PhoneNumber = "+27 82 123 4567",
                Address = "123 Main Street, Cape Town, 8001",
                RegisteredAt = DateTime.UtcNow.AddDays(-30)
            },

            new Customer
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarah.johnson@email.com",
                PhoneNumber = "+27 83 234 5678",
                Address = "456 Oak Avenue, Johannesburg, 2000",
                RegisteredAt = DateTime.UtcNow.AddDays(-15)
            },

            new Customer
            {
                Id = 3,
                FirstName = "Mike",
                LastName = "Wilson",
                Email = "mike.wilson@email.com",
                PhoneNumber = "+27 84 345 6789",
                Address = "789 Pine Road, Durban, 4000",
                RegisteredAt = DateTime.UtcNow.AddDays(-7)
            }
            );

        }
    }
}
