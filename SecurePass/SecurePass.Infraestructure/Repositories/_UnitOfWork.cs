using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;

namespace SecurePass.Infraestructure.Repositories
{
    public class UnitOfWork
    {
        private readonly SecurePassApplicationContext _context;

        public DigitalSecurityTipRepository DigitalSecurityTip { get; }
        public DigitalSecurityTipCategoryRepository DigitalSecurityTipCategory { get; }
        public PasswordGenerationRepository PasswordGeneration { get; }
        
        public PasswordStrengthEvaluationRepository PasswordStrengthEvaluation { get; }
        
        public UserRepository User { get; }

        public UnitOfWork(
            DigitalSecurityTipRepository digitalSecurityTipRepository,
            PasswordGenerationRepository passwordGenerationRepository,
            DigitalSecurityTipCategoryRepository digitalSecurityTipCategoryRepository,
            PasswordStrengthEvaluationRepository passwordStrengthEvaluationRepository,
            UserRepository userRepository
            )
        {
            this.DigitalSecurityTip = digitalSecurityTipRepository;
            this.PasswordGeneration = passwordGenerationRepository;
            this.DigitalSecurityTipCategory = digitalSecurityTipCategoryRepository;
            this.PasswordStrengthEvaluation = passwordStrengthEvaluationRepository;
            this.User = userRepository;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
