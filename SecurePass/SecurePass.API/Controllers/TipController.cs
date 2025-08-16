using Microsoft.AspNetCore.Mvc;
using SecurePass.Applicatio.Services;
using SecurePass.Application.Contracts;
using SecurePass.Application.Dtos;
using SecurePass.Application.Services;


namespace SecurePass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class TipController : ControllerBase
    {


        private readonly ITipService _tipService;


        public TipController(ITipService tipService)
        {
            _tipService = tipService;

        }

        [HttpPost("AddDigitalSecurityTipAndCategory")]
        public async Task<IActionResult> AddDigitalSecurityTipAndCategory([FromBody] TipDtoForController tipDtoForController)
        {
            var digitalSecurityTip = await _tipService.AddDigitalSecurityTip(tipDtoForController.DigitalSecurityTipDtoForController);
            var digitalSecurityTipCategory = await _tipService.AddDigitalSecurityTipCategory(tipDtoForController.DigitalSecurityTipCategoryDto);

            return Ok(new { digitalSecurityTip, digitalSecurityTipCategory });
        }
    }
}


