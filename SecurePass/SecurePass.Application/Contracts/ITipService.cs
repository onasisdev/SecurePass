using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Application.Dtos;

namespace SecurePass.Application.Contracts
{
    public interface ITipService
    {
        Task<DigitalSecurityTipDtoForController> AddDigitalSecurityTip(DigitalSecurityTipDtoForController digitalSecurityTipDtoForController);
        Task<DigitalSecurityTipCategoryDto> AddDigitalSecurityTipCategory(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto);
    }
}
