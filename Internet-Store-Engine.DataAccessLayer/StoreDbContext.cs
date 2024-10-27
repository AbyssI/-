using InternetStoreEngine.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetStoreEngine.DataAccessLayer
{
    public class StoreDbContext : IdentityDbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public StoreDbContext() : base()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(m => m.Description)
                    .HasMaxLength(500);

                entity.Property(m => m.Rating)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(c => c.Parid)
                    .WithMany()
                    .HasForeignKey(i => i.ParidId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Previd)
                    .WithMany()
                    .HasForeignKey(i => i.PrevidId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(c => c.CreateAt)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(c => c.UpdateAt)
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(i => i.Name)
                    .HasMaxLength(200);

                entity.Property(i => i.Picture)
                    .IsRequired();

                entity.HasOne(i => i.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(p => p.Author)
                    .HasMaxLength(100);

                entity.Property(p => p.Genre)
                    .HasMaxLength(100);

                entity.Property(p => p.Price)
                    .IsRequired();

                entity.Property(p => p.Description)
                    .HasMaxLength(500);

                entity.HasMany(p => p.Images)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.Categories)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        j => j
                            .HasOne<Category>()
                            .WithMany()
                            .HasForeignKey("CategoryId")
                            .OnDelete(DeleteBehavior.Restrict),
                        j => j
                            .HasOne<Product>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.Cascade)
                    );

                entity.Property(p => p.CreateAt)
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.UpdateAt)
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.HasKey(le => le.Id);

                entity.Property(le => le.Message)
                    .HasMaxLength(500);

                entity.Property(le => le.Level)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(le => le.Logger)
                    .HasMaxLength(100);

                entity.Property(le => le.Callsite)
                    .HasMaxLength(200);

                entity.Property(le => le.LogTime)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}