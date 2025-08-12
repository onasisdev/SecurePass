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
        public PasswordGenerationRepository PasswordGeneration { get; }
        public PasswordGeneration_PasswordStrengthEvaluationRepository PasswordGeneration_PasswordStrengthEvaluation { get; }
        public PasswordStrengthEvaluationRepository PasswordStrengthEvaluation { get; }
        
        public UserRepository User { get; }

        public UnitOfWork(
            DigitalSecurityTipRepository digitalSecurityTipRepository,
            PasswordGenerationRepository passwordGenerationRepository,
            PasswordGeneration_PasswordStrengthEvaluationRepository PasswordGeneration_PasswordStrengthEvaluationRepository,
            PasswordStrengthEvaluationRepository passwordStrengthEvaluationRepository,
            UserRepository userRepository
            )
        {
            this.DigitalSecurityTip = digitalSecurityTipRepository;
            this.PasswordGeneration = passwordGenerationRepository;
            this.PasswordGeneration_PasswordStrengthEvaluation = PasswordGeneration_PasswordStrengthEvaluationRepository;
            this.PasswordStrengthEvaluation = passwordStrengthEvaluationRepository;
            this.User = userRepository;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
