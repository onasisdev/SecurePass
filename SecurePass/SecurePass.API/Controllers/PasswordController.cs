using Microsoft.AspNetCore.Mvc;
using SecurePass.Applicatio.Services;
using SecurePass.Application.Contracts;
using SecurePass.Application.Dtos;
using SecurePass.Application.Services;
using static SecurePass.Application.Services.PasswordService;

namespace SecurePass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class PasswordController : ControllerBase
    {

        private readonly IPasswordService _passwordService;
       



        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;

        }

        [HttpPost("GenerateAndEvaluate")]
        public async Task<IActionResult> GenerateAndEvaluate([FromBody] PasswordStrengthEvaluationAndGenerationDtoForController passwordEvaluationOrGenerationDto)
        {
            var password = await _passwordService.GeneratePassword(passwordEvaluationOrGenerationDto.PasswordGenerationDtoForController);
            var evaluation = await _passwordService.EvaluatePasswordStrength(passwordEvaluationOrGenerationDto.PasswordStrengthEvaluationDtoForController, passwordEvaluationOrGenerationDto.PasswordGenerationDtoForController);

            return Ok(new { password, evaluation});
        }
    }
}


