using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface IDigitalSecurityTipService
    {
        Task<List<DigitalSecurityTipDto>> GetAllDigitalSecurityTipAsync();
        Task<DigitalSecurityTipDto> GetDigitalSecurityTipByIdAsync(int id);
        Task AddDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto);

        Task UpdateDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto);

        Task DeleteDigitalSecurityTipAsync(int id);


    }
}