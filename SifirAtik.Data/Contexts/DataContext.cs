using Microsoft.EntityFrameworkCore;
using SifirAtik.Domain.Entities;

namespace SifirAtik.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasOne(d => d.CreatedBy)
                .WithMany(p => p.Requests)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.CreatedBy)
                .WithMany(u => u.DonatedItems)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.AdoptedBy)
                .WithMany(u => u.AdoptedItems)
                .HasForeignKey(i => i.AdoptedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.StoredAt)
                .WithMany(w => w.Items)
                .HasForeignKey(i => i.StoredAtId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}
