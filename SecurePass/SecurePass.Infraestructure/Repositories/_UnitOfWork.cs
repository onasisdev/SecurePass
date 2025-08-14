using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Infraestructure.Repositories
{
    public class UnitOfWork
    {
        private readonly SecurePassApplicationContext _context;

        public IDigitalSecurityTipRepository DigitalSecurityTip { get; }
        public IDigitalSecurityTipCategoryRepository DigitalSecurityTipCategory { get; }
        public IPasswordGenerationRepository PasswordGeneration { get; }
        
        public IPasswordStrengthEvaluationRepository PasswordStrengthEvaluation { get; }
        
        public IUserRepository User { get; }

        public UnitOfWork(
            IDigitalSecurityTipRepository digitalSecurityTipRepository,
            IDigitalSecurityTipCategoryRepository digitalSecurityTipCategoryRepository,
            IPasswordGenerationRepository passwordGenerationRepository,
            
            IPasswordStrengthEvaluationRepository passwordStrengthEvaluationRepository,
            IUserRepository userRepository
            )
        {
            this.DigitalSecurityTip = digitalSecurityTipRepository;
            this.DigitalSecurityTipCategory = digitalSecurityTipCategoryRepository;
            this.PasswordGeneration = passwordGenerationRepository;
            
            this.PasswordStrengthEvaluation = passwordStrengthEvaluationRepository;
            this.User = userRepository;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
