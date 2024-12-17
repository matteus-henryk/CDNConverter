using Microsoft.EntityFrameworkCore;
using CDNConverter.API.Domain.Entities;

namespace CDNConverter.API.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<OriginalLog> OriginalLogs { get; set; }
        public DbSet<ConvertedLog> ConvertedLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OriginalLog>(e =>
            {
                e.HasKey(l => l.Id);
                e.Property(l => l.OriginalLogPath).IsRequired();
            });
            modelBuilder.Entity<ConvertedLog>(e =>
            {
                e.HasKey(l => l.Id);
                e.Property(l => l.ConvertedLogPath).IsRequired();
                e.HasOne(l => l.OriginalLog)
                    .WithOne()
                    .HasForeignKey<ConvertedLog>(o => o.OriginalLogId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
