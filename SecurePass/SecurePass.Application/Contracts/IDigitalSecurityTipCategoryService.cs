using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface IDigitalSecurityTipCategoryService
    {
        Task<List<DigitalSecurityTipCategoryDto>> GetAllDigitalSecurityTipCategoryAsync();
        Task<DigitalSecurityTipCategoryDto> GetDigitalSecurityTipCategoryByIdAsync(int id);
        Task AddDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto);

        Task UpdateDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto);

        Task DeleteDigitalSecurityTipCategoryAsync(int id);


    }
}