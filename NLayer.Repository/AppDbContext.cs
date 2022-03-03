using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public override int SaveChanges()
        {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                                entityReferance.UpdatedTime = DateTime.Now;
                                break;
                            }
                    }

                }
            }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                            case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                                entityReferance.UpdatedTime = DateTime.Now;
                                break;
                            }
                    }
                    
                }
            }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id = 1,
                Color = "Red",
                Height = 20,
                Width = 20,
                ProductId = 1,
            },
            new ProductFeature
            {
                Id = 2,
                Color = "Blue",
                Height = 20,
                Width = 20,
                ProductId = 2,
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
