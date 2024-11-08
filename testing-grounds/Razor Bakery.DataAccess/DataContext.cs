using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Razor_Bakery.entities;
using System.Data.Common;

namespace Razor_Bakery.DataAccess
{
    public class DataContext : DbContext
    {
        //protected readonly string dbKey = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RazorBakery;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig()).Seed();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(dbKey);
        //}

        public DbSet<Product> Products { get; set; }
    }

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ImageName)
                .HasColumnName("ImageFilename");

            builder.Property(p => p.Price)
                .HasPrecision(18, 2); // 18 digits, 2 decimal places
        }
    }

    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product {
                        Id = 1, 
                        Name = "Carrot Cake", 
                        Description = "A nice slice of carrot cake with almonds on top", 
                        Price = 6.99m, 
                        ImageName = "carrot_cake.jpg"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Lemon Tart",
                        Description = "A delicious lemon tart with fresh meringue cooked to perfection",
                        Price = 9.99m,
                        ImageName = "lemon_tart.jpg"
                    },
                new Product
                {
                    Id = 3,
                    Name = "Cupcakes",
                    Description = "Delectable vanilla and chocolate cupcakes",
                    Price = 5.99m,
                    ImageName = "cupcakes.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Bread",
                    Description = "Fresh baked French-style bread",
                    Price = 1.49m,
                    ImageName = "bread.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Pear Tart",
                    Description = "A glazed pear tart topped with sliced almonds and a dash of cinnamon",
                    Price = 5.99m,
                    ImageName = "pear_tart.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Chocolate Cake",
                    Description = "Rich chocolate frosting cover this chocolate lover's dream",
                    Price = 8.99m,
                    ImageName = "chocolate_cake.jpg"
                }

                );

            return modelBuilder;
        }
    }
}
