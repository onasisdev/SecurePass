using SecurePass.Application.Dtos;

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