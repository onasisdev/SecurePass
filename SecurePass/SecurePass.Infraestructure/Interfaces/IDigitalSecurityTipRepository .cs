using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;

namespace SecurePass.Infrastructure.Interfaces
{
    public interface IDigitalSecurityTipRepository
    {
        Task<List<DigitalSecurityTip>> GetAllDigitalSecurityTipAsync();
        Task<DigitalSecurityTip> GetDigitalSecurityTipByIdAsync(int id);
        Task AddDigitalSecurityTipAsync(DigitalSecurityTip digitalSecurityTip);
        Task UpdateDigitalSecurityTipAsync(DigitalSecurityTip digitalSecurityTip);
        Task DeleteDigitalSecurityTipAsync(int id);
    }
}
