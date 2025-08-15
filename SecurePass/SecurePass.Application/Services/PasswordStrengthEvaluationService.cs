using SecurePass.Application.Contracts;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Application.Dtos;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Applicatio.Services
{
    public class PasswordStrengthEvaluationService : IPasswordStrengthEvaluationService
    {
        private readonly IPasswordStrengthEvaluationRepository _repo;
        private readonly UnitOfWork _unitOfWork;
        


        public PasswordStrengthEvaluationService(IPasswordStrengthEvaluationRepository _repo, UnitOfWork _unitOfWork)
        {
            this._repo = _repo;
            this._unitOfWork = _unitOfWork;
        }

        public async Task<List<PasswordStrengthEvaluationDto>> GetAllPasswordStrengthEvaluationAsync()
        {

            var passwordStrengthEvaluation = await _repo.GetAllPasswordStrengthEvaluationAsync();
            return passwordStrengthEvaluation.Select(c => new PasswordStrengthEvaluationDto
            {
                Id = c.Id,
                StrengthLevel = c.StrengthLevel,
                SuggestionMessage = c.SuggestionMessage,


                PasswordGeneration = new PasswordGenerationDto
                {
                    Id = c.PasswordGeneration.Id,
                    PasswordLength = c.PasswordGeneration.PasswordLength,
                    IncludeUpperCaseLetter = c.PasswordGeneration.IncludeUpperCaseLetter,
                    IncludeLowerCaseLetter = c.PasswordGeneration.IncludeLowerCaseLetter,
                    IncludeNumber = c.PasswordGeneration.IncludeNumber,
                    IncludeSpecialCharacter = c.PasswordGeneration.IncludeSpecialCharacter,

                }

            }).ToList();
        }



        public async Task<PasswordStrengthEvaluationDto> GetPasswordStrengthEvaluationByIdAsync(int id)
        {
            var passwordStrengthEvaluation = await _unitOfWork.PasswordStrengthEvaluation.GetPasswordStrengthEvaluationByIdAsync(id);

            if (passwordStrengthEvaluation == null)
            {
                return null;
            }

            return new PasswordStrengthEvaluationDto
            {
                Id = passwordStrengthEvaluation.Id,
                StrengthLevel = passwordStrengthEvaluation.StrengthLevel,
                SuggestionMessage = passwordStrengthEvaluation.SuggestionMessage,

            };

        }

        public async Task AddPasswordStrengthEvaluationAsync(PasswordStrengthEvaluationDto passwordStrengthEvaluationDto)
        {
            var passwordStrengthEvaluationEntity = new PasswordStrengthEvaluation
            {
                Id = passwordStrengthEvaluationDto.Id,
                StrengthLevel = passwordStrengthEvaluationDto.StrengthLevel,
                SuggestionMessage = passwordStrengthEvaluationDto.SuggestionMessage,
            };

            await _unitOfWork.PasswordStrengthEvaluation.AddPasswordStrengthEvaluationAsync(passwordStrengthEvaluationEntity);


        }

        public async Task UpdatePasswordStrengthEvaluationAsync(PasswordStrengthEvaluationDto passwordStrengthEvaluationDto)
        {
            var passwordStrengthEvaluationEntity = await _unitOfWork.PasswordStrengthEvaluation.GetPasswordStrengthEvaluationByIdAsync(passwordStrengthEvaluationDto.Id);

            passwordStrengthEvaluationEntity.StrengthLevel = passwordStrengthEvaluationDto.StrengthLevel;
            passwordStrengthEvaluationEntity.SuggestionMessage = passwordStrengthEvaluationDto.SuggestionMessage;

            await _unitOfWork.PasswordStrengthEvaluation.UpdatePasswordStrengthEvaluationAsync(passwordStrengthEvaluationEntity);
        }

        public async Task DeletePasswordStrengthEvaluationAsync(int id)
        {
            await _unitOfWork.PasswordStrengthEvaluation.DeletePasswordStrengthEvaluationAsync(id);
        }

        
    }
}