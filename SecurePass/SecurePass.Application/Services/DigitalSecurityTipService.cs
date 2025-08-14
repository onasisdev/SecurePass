using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;

namespace SecurePass.Applicatio.Services
{
    public class DigitalSecurityTipService
    {
        private readonly DigitalSecurityTipRepository _repo;
        private readonly UnitOfWork _unitOfWork;


        public DigitalSecurityTipService(DigitalSecurityTipRepository _repo, UnitOfWork _unitOfWork)
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
                DynamicUpdateOfTip = c.DynamicUpdateOfTip,


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
                DynamicUpdateOfTip = digitalSecurityTip.DynamicUpdateOfTip,

            };



        }

        public async Task AddDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto)
        {
            var digitalSecurityTipEntity = new DigitalSecurityTip
            {
                GoodPractice = digitalSecurityTipDto.GoodPractice,
                DynamicUpdateOfTip = digitalSecurityTipDto.DynamicUpdateOfTip,
            };

            await _unitOfWork.DigitalSecurityTip.AddDigitalSecurityTipAsync(digitalSecurityTipEntity);


        }

        public async Task UpdateDigitalSecurityTipAsync(DigitalSecurityTipDto digitalSecurityTipDto)
        {
            var digitalSecurityTipEntity = await _unitOfWork.DigitalSecurityTip.GetDigitalSecurityTipByIdAsync(digitalSecurityTipDto.Id);

            digitalSecurityTipEntity.GoodPractice = digitalSecurityTipDto.GoodPractice;
            digitalSecurityTipEntity.DynamicUpdateOfTip = digitalSecurityTipDto.DynamicUpdateOfTip;


            await _unitOfWork.DigitalSecurityTip.UpdateDigitalSecurityTipAsync(digitalSecurityTipEntity);
        }

        public async Task DeleteDigitalSecurityTipAsync(int id)
        {
            await _unitOfWork.DigitalSecurityTip.DeleteDigitalSecurityTipAsync(id);
        }






    }
}
