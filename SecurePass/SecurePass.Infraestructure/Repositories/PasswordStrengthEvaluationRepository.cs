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
    public class PasswordStrengthEvaluationRepository
    {
        private readonly SecurePassApplicationContext _context;

        public PasswordStrengthEvaluationRepository(SecurePassApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<PasswordStrengthEvaluation>> GetAllPasswordStrengthEvaluationAsync()
        {
            return await _context.PasswordStrengthEvaluations
                .Include(g => g.User)
                .Include(g => g.PasswordGeneration)
                .ToListAsync();
        }

        public async Task<PasswordStrengthEvaluation> GetPasswordStrengthEvaluationByIdAsync(int id)
        {
            return await _context.PasswordStrengthEvaluations
                .Include(g => g.User)
                .Include(g => g.PasswordGeneration)
                .FirstOrDefaultAsync(g => g.Id == id);



        }

        public async Task AddPasswordStrengthEvaluationAsync(PasswordStrengthEvaluation passwordStrengthEvaluation)
        {
            _context.PasswordStrengthEvaluations.Add(passwordStrengthEvaluation);
            
        }

        public async Task UpdatePasswordStrengthEvaluationAsync(PasswordStrengthEvaluation passwordStrengthEvaluation)
        {
            _context.PasswordStrengthEvaluations.Update(passwordStrengthEvaluation);
            
        }

        public async Task DeletePasswordStrengthEvaluationAsync(int id)
        {
            var passwordStrengthEvaluation = await _context.PasswordStrengthEvaluations.FindAsync(id);

            if (passwordStrengthEvaluation != null)
            {
                _context.PasswordStrengthEvaluations.Remove(passwordStrengthEvaluation);
                
            }
        }








    }
}
