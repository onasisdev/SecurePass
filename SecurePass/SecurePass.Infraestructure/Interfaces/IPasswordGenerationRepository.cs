using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;

namespace SecurePass.Infrastructure.Interfaces
{
    public interface IPasswordGenerationRepository
    {
        Task<List<PasswordGeneration>> GetAllPasswordGenerationAsync();
        Task<PasswordGeneration> GetPasswordGenerationByIdAsync(int id);
        Task AddPasswordGenerationAsync(PasswordGeneration passwordGeneration);
        Task UpdatePasswordGenerationAsync(PasswordGeneration passwordGeneration);
        Task DeletePasswordGenerationAsync(int id);
    }
}
