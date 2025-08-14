using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface IPasswordStrengthEvaluationService
    {
        Task<List<PasswordStrengthEvaluationDto>> GetAllPasswordStrengthEvaluationAsync();
        Task<PasswordStrengthEvaluationDto> GetPasswordStrengthEvaluationByIdAsync(int id);
        Task AddPasswordStrengthEvaluationAsync(PasswordStrengthEvaluationDto passwordStrengthEvaluationDto);

        Task UpdatePasswordStrengthEvaluationAsync(PasswordStrengthEvaluationDto passwordStrengthEvaluationDto);

        Task DeletePasswordStrengthEvaluationAsync(int id);


    }
}