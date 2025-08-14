using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;

namespace SecurePass.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;
        private readonly UnitOfWork _unitOfWork;


        public UserService(UserRepository _repo, UnitOfWork _unitOfWork)
        {
            this._repo = _repo;
            this._unitOfWork = _unitOfWork;
        }

        public async Task<List<UserDto>> GetAllUserAsync()
        {

            var user = await _repo.GetAllUserAsync();
            return user.Select(c => new UserDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Password = c.Password,


                PasswordGeneration = new PasswordGenerationDto
                {
                    Id = c.PasswordGeneration.Id,
                    PasswordLength = c.PasswordGeneration.PasswordLength,
                    IncludeUpperCaseLetter = c.PasswordGeneration.IncludeUpperCaseLetter,
                    IncludeLowerCaseLetter = c.PasswordGeneration.IncludeLowerCaseLetter,
                    IncludeNumber = c.PasswordGeneration.IncludeNumber,
                    IncludeSpecialCharacter = c.PasswordGeneration.IncludeSpecialCharacter,

                },

                PasswordStrengthEvaluations = c.PasswordStrengthEvaluations.Select(d => new PasswordStrengthEvaluationDto
                {
                    Id = d.Id,
                    StrengthLevel = d.StrengthLevel,
                    GoodOrBadAspect = d.GoodOrBadAspect,
                    SuggestionMessage = d.SuggestionMessage,
                }


                ).ToList()

            }).ToList();
        }



        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.User.GetUserByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,

            };

        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var userEntity = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
            };

            await _unitOfWork.User.AddUserAsync(userEntity);


        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var userEntity = await _unitOfWork.User.GetUserByIdAsync(userDto.Id);

            userEntity.Id = userDto.Id;
            userEntity.Name = userDto.Name;
            userEntity.Email = userDto.Email;
            userEntity.Password = userDto.Password;



            await _unitOfWork.User.UpdateUserAsync(userEntity);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _unitOfWork.User.DeleteUserAsync(id);
        }
    }
}
