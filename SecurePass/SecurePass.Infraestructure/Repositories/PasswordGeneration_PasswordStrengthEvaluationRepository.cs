using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Infraestructure.Data;
using SecurePass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SecurePass.Infraestructure.Repositories
{
    public class PasswordGeneration_PasswordStrengthEvaluationRepository
    {
        private readonly SecurePassApplicationContext _context;

        public PasswordGeneration_PasswordStrengthEvaluationRepository(SecurePassApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<PasswordGeneration_PasswordStrengthEvaluation>> GetAllpasswordGenerations_passwordStrengthEvaluationsAsync(int passwordGenerationId)
        {
            return await _context.PasswordGenerations_PasswordStrengthEvaluations
                .Include(g => g.PasswordGeneration)
                .Include(g => g.PasswordStrengthEvaluation)
                .Where(g => g.PasswordGenerationId == passwordGenerationId)
                .ToListAsync();
        }

        public async Task<PasswordGeneration_PasswordStrengthEvaluation> GetpasswordGenerations_passwordStrengthEvaluationsById(int id)
        {
            return await _context.PasswordGenerations_PasswordStrengthEvaluations
                .FirstOrDefaultAsync(g => g.Id == id);

        }

        public async Task AddpasswordGenerations_passwordStrengthEvaluationsAsync(PasswordGeneration_PasswordStrengthEvaluation passwordGenerations_passwordStrengthEvaluations)
        {
            _context.PasswordGenerations_PasswordStrengthEvaluations.Add(passwordGenerations_passwordStrengthEvaluations);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatepasswordGenerations_passwordStrengthEvaluationsAsync(PasswordGeneration_PasswordStrengthEvaluation passwordGenerations_passwordStrengthEvaluations)
        {
            _context.PasswordGenerations_PasswordStrengthEvaluations.Update(passwordGenerations_passwordStrengthEvaluations);
            await _context.SaveChangesAsync();
        }

        public async Task DeletepasswordGenerations_passwordStrengthEvaluationsAsync(int id)
        {
            var passwordGenerations_passwordStrengthEvaluations = await _context.PasswordGenerations_PasswordStrengthEvaluations.FindAsync(id);

            if (passwordGenerations_passwordStrengthEvaluations != null)
            {
                _context.PasswordGenerations_PasswordStrengthEvaluations.Remove(passwordGenerations_passwordStrengthEvaluations);
                await _context.SaveChangesAsync();
            }
        }
    }
}
