using SecurePass.Application.Contracts;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Application.Dtos;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Application.Services
{
    public class DigitalSecurityTipCategoryService : IDigitalSecurityTipCategoryService
    {
     
        private readonly UnitOfWork _unitOfWork;
        private readonly IDigitalSecurityTipCategoryRepository _repo;


        public DigitalSecurityTipCategoryService(IDigitalSecurityTipCategoryRepository _repo, UnitOfWork _unitOfWork)
        {
          
            this._unitOfWork = _unitOfWork;
            this._repo = _repo;
        }

        public async Task<List<DigitalSecurityTipCategoryDto>> GetAllDigitalSecurityTipCategoryAsync()
        {

            var digitalSecurityTipCategory = await _repo.GetAllDigitalSecurityTipCategoryAsync();
            return digitalSecurityTipCategory.Select(c => new DigitalSecurityTipCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,


            }).ToList();


        }

        public async Task<DigitalSecurityTipCategoryDto> GetDigitalSecurityTipCategoryByIdAsync(int id)
        {
            var digitalSecurityTipCategory = await _unitOfWork.DigitalSecurityTipCategory.GetDigitalSecurityTipCategoryByIdAsync(id);

            if (digitalSecurityTipCategory == null)
            {
                return null;
            }

            return new DigitalSecurityTipCategoryDto
            {
                Id = digitalSecurityTipCategory.Id,
                Name = digitalSecurityTipCategory.Name,
                Description = digitalSecurityTipCategory.Description,


            };



        }

        public async Task AddDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto)
        {
            var digitalSecurityTipCategoryEntity = new DigitalSecurityTipCategory
            {
                Id = digitalSecurityTipCategoryDto.Id,
                Name = digitalSecurityTipCategoryDto.Name,
                Description = digitalSecurityTipCategoryDto.Description,

            };

            await _unitOfWork.DigitalSecurityTipCategory.AddDigitalSecurityTipCategoryAsync(digitalSecurityTipCategoryEntity);


        }

        public async Task UpdateDigitalSecurityTipCategoryAsync(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto)
        {
            var digitalSecurityTipCategoryEntity = await _unitOfWork.DigitalSecurityTipCategory.GetDigitalSecurityTipCategoryByIdAsync(digitalSecurityTipCategoryDto.Id);

            digitalSecurityTipCategoryEntity.Id = digitalSecurityTipCategoryDto.Id;
            digitalSecurityTipCategoryEntity.Name = digitalSecurityTipCategoryDto.Name;
            digitalSecurityTipCategoryEntity.Description = digitalSecurityTipCategoryDto.Description;



            await _unitOfWork.DigitalSecurityTipCategory.UpdateDigitalSecurityTipCategoryAsync(digitalSecurityTipCategoryEntity);
        }

        public async Task DeleteDigitalSecurityTipCategoryAsync(int id)
        {
            await _unitOfWork.DigitalSecurityTipCategory.DeleteDigitalSecurityTipCategoryAsync(id);
        }






    }
}
