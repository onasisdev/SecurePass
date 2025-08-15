using SecurePass.Application.Contracts;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Application.Dtos;
using SecurePass.Infrastructure.Interfaces;

namespace SecurePass.Applicatio.Services
{
    public class DigitalSecurityTipService : IDigitalSecurityTipService
    {
        private readonly IDigitalSecurityTipRepository _repo;
        private readonly UnitOfWork _unitOfWork;


        public DigitalSecurityTipService(IDigitalSecurityTipRepository _repo, UnitOfWork _unitOfWork)
        {
            this._repo = _repo;
            this._unitOfWork = _unitOfWork;
        }

        public async Task<List<DigitalSecurityTipDto>> GetAllDigitalSecurityTipAsync()
        {

            var digitalSecurityTip = await _repo.GetAllDigitalSecurityTipAsync();
            return digitalSecurityTip.Select(c => new DigitalSecurityTipDto
            {
                Id = c.Id,
                GoodPractice = c.GoodPractice,
                


            }).ToList();
           
   
        }

        public async Task<DigitalSecurityTipDto> GetDigitalSecurityTipByIdAsync(int id)
        {
            var digitalSecurityTip = await _unitOfWork.DigitalSecurityTip.GetDigitalSecurityTipByIdAsync(id);

            if (digitalSecurityTip == null)
            {
                return null;
            }

            return new DigitalSecurityTipDto
            {
                Id = digitalSecurityTip.Id,
                GoodPractice = digitalSecurityTip.GoodPractice,
                

            };



        }

        public async Task AddDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto)
        {
            var digitalSecurityTipEntity = new DigitalSecurityTip
            {
                GoodPractice = digitalSecurityTipDto.GoodPractice,
                
            };

            await _unitOfWork.DigitalSecurityTip.AddDigitalSecurityTipAsync(digitalSecurityTipEntity);


        }

        public async Task UpdateDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto)
        {
            var digitalSecurityTipEntity = await _unitOfWork.DigitalSecurityTip.GetDigitalSecurityTipByIdAsync(digitalSecurityTipDto.Id);

            digitalSecurityTipEntity.GoodPractice = digitalSecurityTipDto.GoodPractice;
            


            await _unitOfWork.DigitalSecurityTip.UpdateDigitalSecurityTipAsync(digitalSecurityTipEntity);
        }

        public async Task DeleteDigitalSecurityTipAsync(int id)
        {
            await _unitOfWork.DigitalSecurityTip.DeleteDigitalSecurityTipAsync(id);
        }






    }
}
