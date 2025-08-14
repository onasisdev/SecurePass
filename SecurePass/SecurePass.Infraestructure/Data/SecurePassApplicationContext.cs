using Microsoft.EntityFrameworkCore;
using SecurePass.Domain.Entities;

namespace SecurePass.Infraestructure.Data
{
    public class SecurePassApplicationContext : DbContext
    {
        public SecurePassApplicationContext(DbContextOptions<SecurePassApplicationContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>()
                .HasOne(u => u.PasswordGeneration)
                .WithOne(p => p.User)
                .HasForeignKey<PasswordGeneration>(p => p.UserId);

            modelBuilder.Entity<PasswordStrengthEvaluation>()
            .HasOne(p => p.User)
            .WithMany(u => u.PasswordStrengthEvaluations)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PasswordStrengthEvaluation>()
         .HasOne(p => p.PasswordGeneration)
         .WithMany(pg => pg.PasswordStrengthEvaluations)
         .HasForeignKey(p => p.PasswordGenerationId)
         .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PasswordGeneration> PasswordGenerations { get; set; }
        public DbSet<PasswordStrengthEvaluation> PasswordStrengthEvaluations { get; set; }
        public DbSet<DigitalSecurityTip> DigitalSecurityTips { get; set; }
        public DbSet<DigitalSecurityTipCategory> DigitalSecurityTipCategories { get; set; }

    }
}
