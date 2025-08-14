using SecurePass.Application.Contracts;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Application.Dtos;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Applicatio.Services
{
    public class PasswordGenerationService : IPasswordGenerationService
    {
        private readonly IPasswordGenerationRepository _repo;
        private readonly UnitOfWork _unitOfWork;


        public PasswordGenerationService(IPasswordGenerationRepository _repo, UnitOfWork _unitOfWork)
        {
            this._repo = _repo;
            this._unitOfWork = _unitOfWork;
        }

        public async Task<List<PasswordGenerationDto>> GetAllPasswordGenerationAsync()
        {

            var passwordGeneration = await _repo.GetAllPasswordGenerationAsync();
            return passwordGeneration.Select(c => new PasswordGenerationDto
            {
                Id = c.Id,
                PasswordLength = c.PasswordLength,
                IncludeUpperCaseLetter = c.IncludeUpperCaseLetter,
                IncludeLowerCaseLetter = c.IncludeLowerCaseLetter,
                IncludeNumber = c.IncludeNumber,
                IncludeSpecialCharacter = c.IncludeSpecialCharacter,

                PasswordStrengthEvaluations = c.PasswordStrengthEvaluations.Select(d => new PasswordStrengthEvaluationDto

                {
                    Id = d.Id,
                    StrengthLevel = d.StrengthLevel,
                    GoodOrBadAspect = d.GoodOrBadAspect,
                    SuggestionMessage = d.SuggestionMessage,

                }).ToList()

            }).ToList();

        }

        public async Task<PasswordGenerationDto> GetPasswordGenerationByIdAsync(int id)
        {
            var PasswordGeneration = await _unitOfWork.PasswordGeneration.GetPasswordGenerationByIdAsync(id);

            if (PasswordGeneration == null)
            {
                return null;
            }

            return new PasswordGenerationDto
            {
                Id = PasswordGeneration.Id,
                PasswordLength = PasswordGeneration.PasswordLength,
                IncludeUpperCaseLetter = PasswordGeneration.IncludeUpperCaseLetter,
                IncludeLowerCaseLetter = PasswordGeneration.IncludeLowerCaseLetter,
                IncludeNumber = PasswordGeneration.IncludeNumber,
                IncludeSpecialCharacter = PasswordGeneration.IncludeSpecialCharacter,

            };



        }

        public async Task AddPasswordGenerationAsync(PasswordGenerationDto PasswordGenerationDto)
        {
            var passwordGenerationEntity = new PasswordGeneration
            {
                PasswordLength = PasswordGenerationDto.PasswordLength,
                IncludeUpperCaseLetter = PasswordGenerationDto.IncludeUpperCaseLetter,
                IncludeLowerCaseLetter = PasswordGenerationDto.IncludeLowerCaseLetter,
                IncludeNumber = PasswordGenerationDto.IncludeNumber,
                IncludeSpecialCharacter = PasswordGenerationDto.IncludeSpecialCharacter,
            };

            await _unitOfWork.PasswordGeneration.AddPasswordGenerationAsync(passwordGenerationEntity);


        }

        public async Task UpdatePasswordGenerationAsync(PasswordGenerationDto PasswordGenerationDto)
        {
            var passwordGenerationEntity = await _unitOfWork.PasswordGeneration.GetPasswordGenerationByIdAsync(PasswordGenerationDto.Id);

            passwordGenerationEntity.PasswordLength = PasswordGenerationDto.PasswordLength;
            passwordGenerationEntity.IncludeUpperCaseLetter = PasswordGenerationDto.IncludeUpperCaseLetter;
            passwordGenerationEntity.IncludeLowerCaseLetter = PasswordGenerationDto.IncludeLowerCaseLetter;
            passwordGenerationEntity.IncludeNumber = PasswordGenerationDto.IncludeNumber;
            passwordGenerationEntity.IncludeSpecialCharacter = PasswordGenerationDto.IncludeSpecialCharacter;


            await _unitOfWork.PasswordGeneration.UpdatePasswordGenerationAsync(passwordGenerationEntity);
        }

        public async Task DeletePasswordGenerationAsync(int id)
        {
            await _unitOfWork.PasswordGeneration.DeletePasswordGenerationAsync(id);
        }

    }
}
