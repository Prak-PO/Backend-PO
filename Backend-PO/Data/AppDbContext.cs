using Backend_PO.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_PO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Kurs> Kursy => Set<Kurs>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(k => k.Title).IsRequired().HasMaxLength(200);
                entity.Property(k => k.Description).HasMaxLength(4000);
                entity.HasOne(k => k.Author)
                      .WithMany(u => u.AuthoredCourses)
                      .HasForeignKey(k => k.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Content).IsRequired().HasMaxLength(2000);
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.Kurs)
                      .WithMany(k => k.Comments)
                      .HasForeignKey(c => c.KursId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Rating).IsRequired();
                entity.HasCheckConstraint("CK_Feedback_Rating_Range", "\"Rating\" >= 1 AND \"Rating\" <= 5");
                entity.HasOne(f => f.User)
                      .WithMany(u => u.Feedbacks)
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.Kurs)
                      .WithMany(k => k.Feedbacks)
                      .HasForeignKey(f => f.KursId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}


