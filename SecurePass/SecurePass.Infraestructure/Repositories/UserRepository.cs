using Microsoft.EntityFrameworkCore;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;

namespace SecurePass.Infraestructure.Repositories
{
    public class UserRepository
    {
        private readonly SecurePassApplicationContext _context;

        public UserRepository(SecurePassApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users
                .Include(g => g.PasswordGeneration)
                .Include(g => g.PasswordStrengthEvaluations)
                .ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Include(g => g.PasswordGeneration)
                .Include(g => g.PasswordStrengthEvaluations)
                .FirstOrDefaultAsync(g => g.Id == id);



        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
