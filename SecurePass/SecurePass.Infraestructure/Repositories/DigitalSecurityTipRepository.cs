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
    public class DigitalSecurityTipRepository
    {
        private readonly SecurePassApplicationContext _context;

        public DigitalSecurityTipRepository(SecurePassApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<DigitalSecurityTip>> GetAllDigitalSecurityTipAsync()
        {
            return await _context.DigitalSecurityTips
                .Include(g => g.User)
                .ToListAsync();
        }

        public async Task<DigitalSecurityTip> GetDigitalSecurityTipByIdAsync(int id)
        {
            return await _context.DigitalSecurityTips
                .Include(g => g.User)
                .FirstOrDefaultAsync(g => g.Id == id);

        }

        public async Task AddDigitalSecurityTipAsync(DigitalSecurityTip digitalSecurityTip)
        {
            _context.DigitalSecurityTips.Add(digitalSecurityTip);
            
        }

        public async Task UpdateDigitalSecurityTipAsync(DigitalSecurityTip digitalSecurityTip)
        {
            _context.DigitalSecurityTips.Update(digitalSecurityTip);
            
        }

        public async Task DeleteDigitalSecurityTipAsync(int id)
        {
            var digitalSecurityTip = await _context.DigitalSecurityTips.FindAsync(id);

            if (digitalSecurityTip != null)
            {
                _context.DigitalSecurityTips.Remove(digitalSecurityTip);
                
            }
        }






    }
}
