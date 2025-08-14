using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUserAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDto userDto);

        Task UpdateUserAsync(UserDto userDto);

        Task DeleteUserAsync(int id);


    }
}