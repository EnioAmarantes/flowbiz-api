using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FlowBiz.Domain.Entities;

namespace FlowBiz.Infrastructure.Data;
public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(10, 4, 24))
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasQueryFilter(c => c.IsActive);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.CreatedAt).IsRequired();
                entity.Property(c => c.Description).IsRequired(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasQueryFilter(p => p.IsActive);
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.CreatedAt).IsRequired();
                entity.Property(p => p.Description).IsRequired(false);
                entity.Property(p => p.Code).IsRequired();
                entity.Property(p => p.Price);

                // Configuração da relação entre Product e Category
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }