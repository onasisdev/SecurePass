using Microsoft.EntityFrameworkCore;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Infraestructure.Repositories
{
    public class DigitalSecurityTipCategoryRepository : IDigitalSecurityTipCategoryRepository
    {
        private readonly SecurePassApplicationContext _context;

        public DigitalSecurityTipCategoryRepository(SecurePassApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<DigitalSecurityTipCategory>> GetAllDigitalSecurityTipCategoryAsync()
        {
            return await _context.DigitalSecurityTipCategories
                .Include(g => g.DigitalSecurityTips)
                .ToListAsync();
        }

        public async Task<DigitalSecurityTipCategory> GetDigitalSecurityTipCategoryByIdAsync(int id)
        {
            return await _context.DigitalSecurityTipCategories
                .Include(g => g.DigitalSecurityTips)
                .FirstOrDefaultAsync(g => g.Id == id);

        }

        public async Task AddDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategory digitalSecurityTipCategory)
        {
            _context.DigitalSecurityTipCategories.Add(digitalSecurityTipCategory);

        }

        public async Task UpdateDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategory digitalSecurityTipCategory)
        {
            _context.DigitalSecurityTipCategories.Update(digitalSecurityTipCategory);

        }

        public async Task DeleteDigitalSecurityTipCategoryAsync(int id)
        {
            var digitalSecurityTipCategory = await _context.DigitalSecurityTipCategories.FindAsync(id);

            if (digitalSecurityTipCategory != null)
            {
                _context.DigitalSecurityTipCategories.Remove(digitalSecurityTipCategory);

            }
        }
    }
}
