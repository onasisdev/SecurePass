using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface IPasswordService
    {
     
            Task<string> GeneratePassword(PasswordGenerationDtoForController passwordGenerationDtoForController);

        

        Task<PasswordStrengthEvaluationDtoForController> EvaluatePasswordStrength(PasswordStrengthEvaluationDtoForController passwordStrengthEvaluationDtoForController, PasswordGenerationDtoForController passwordGenerationDtoForController);


    }
}