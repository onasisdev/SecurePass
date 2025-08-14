using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;

namespace SecurePass.Application.Contracts
{
    public interface IPasswordGenerationService
    {
        Task<List<PasswordGenerationDto>> GetAllPasswordGenerationAsync();
        Task<PasswordGenerationDto> GetPasswordGenerationByIdAsync(int id);
        Task AddPasswordGenerationAsync(PasswordGenerationDto PasswordGenerationDto);

        Task UpdatePasswordGenerationAsync(PasswordGenerationDto PasswordGenerationDto);

        Task DeletePasswordGenerationAsync(int id);


    }
}