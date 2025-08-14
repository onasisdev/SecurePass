using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Infraestructure.Data;
using SecurePass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Infraestructure.Repositories
{
    public class PasswordGenerationRepository : IPasswordGenerationRepository
    {
        private readonly SecurePassApplicationContext _context;

        public PasswordGenerationRepository(SecurePassApplicationContext _context) 
        {
            this._context = _context;
        }

        public async Task<List<PasswordGeneration>> GetAllPasswordGenerationAsync()
        {
            return await _context.PasswordGenerations
                .Include(g => g.User)
                .Include(g => g.PasswordStrengthEvaluations)
                .ToListAsync();
        }

        public async Task<PasswordGeneration> GetPasswordGenerationByIdAsync(int id)
        {
            return await _context.PasswordGenerations
                .Include(g => g.User)
                .Include(g => g.PasswordStrengthEvaluations)
                .FirstOrDefaultAsync(g => g.Id == id);

            

        }

        public async Task AddPasswordGenerationAsync(PasswordGeneration passwordGeneration)
        {
            _context.PasswordGenerations .Add(passwordGeneration);
            
        }

        public async Task UpdatePasswordGenerationAsync(PasswordGeneration passwordGeneration)
        {
            _context.PasswordGenerations.Update(passwordGeneration);
            
        }

        public async Task DeletePasswordGenerationAsync(int id)
        {
            var passwordGeneration = await _context.PasswordGenerations.FindAsync(id);

            if (passwordGeneration != null)
            {
                _context.PasswordGenerations.Remove(passwordGeneration);
                
            }
        }
            


         

       

       
    }
}
