using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAlpha.Models;

namespace WebAlpha.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Konfigurera relationen mellan Project och ApplicationUser
            builder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId);

            // Du kan lägga till ytterligare konfigurationer här, t.ex.:

            // Konfigurera index
            builder.Entity<Project>()
                .HasIndex(p => p.Name);

            // Konfigurera defaultvärden
            builder.Entity<Project>()
                .Property(p => p.Status)
                .HasDefaultValue(ProjectStatus.NotStarted);

            // Konfigurera begränsningar
            builder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Project>()
                .Property(p => p.Description)
                .HasMaxLength(500);
        }
    }
}