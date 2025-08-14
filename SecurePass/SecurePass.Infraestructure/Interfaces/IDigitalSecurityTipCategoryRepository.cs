using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;

namespace SecurePass.Infrastructure.Interfaces
{
    public interface IDigitalSecurityTipCategoryRepository
    {
        Task<List<DigitalSecurityTipCategory>> GetAllDigitalSecurityTipCategoryAsync();
        Task<DigitalSecurityTipCategory> GetDigitalSecurityTipCategoryByIdAsync(int id);
        Task AddDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategory digitalSecurityTipCategory);
        Task UpdateDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategory digitalSecurityTipCategory);
        Task DeleteDigitalSecurityTipCategoryAsync(int id);
    }
}
