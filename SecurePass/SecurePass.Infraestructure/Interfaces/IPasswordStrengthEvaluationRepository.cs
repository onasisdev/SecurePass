using SecurePass.Domain.Entities;

namespace SecurePass.Infrastructure.Interfaces
{
    public interface IPasswordStrengthEvaluationRepository
    {
        Task<List<PasswordStrengthEvaluation>> GetAllPasswordStrengthEvaluationAsync();
        Task<PasswordStrengthEvaluation> GetPasswordStrengthEvaluationByIdAsync(int id);
        Task AddPasswordStrengthEvaluationAsync(PasswordStrengthEvaluation passwordStrengthEvaluation);
        Task UpdatePasswordStrengthEvaluationAsync(PasswordStrengthEvaluation passwordStrengthEvaluation);
        Task DeletePasswordStrengthEvaluationAsync(int id);
    }
}
