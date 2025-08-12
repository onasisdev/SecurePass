using Microsoft.EntityFrameworkCore;
using SecurePass.Domain.Entities;

namespace SecurePass.Infraestructure.Data
{
    public class SecurePassApplicationContext : DbContext
    {
        public SecurePassApplicationContext(DbContextOptions o): base(o){}

        public DbSet<User> Users { get; set; }
        public DbSet<PasswordGeneration> PasswordGenerations { get; set; }
        public DbSet<PasswordStrengthEvaluation> PasswordStrengthEvaluations { get; set; }
        public DbSet<DigitalSecurityTip> DigitalSecurityTips { get; set; }
        public DbSet<PasswordGeneration_PasswordStrengthEvaluation> PasswordGenerations_PasswordStrengthEvaluations { get; set; }

    }
}
