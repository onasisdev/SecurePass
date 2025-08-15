using System;
using SecurePass.Infraestructure.Data;
using SecurePass.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePass.Domain.Entities;

namespace SecurePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordStrengthEvaluationController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public PasswordStrengthEvaluationController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPasswordStrengthEvaluations()
        {
            var allpasswordStrengthEvaluations = dbContext.PasswordStrengthEvaluations.ToList();

            return Ok(allpasswordStrengthEvaluations);
        }

        [HttpGet]
        [Route("id{id:int}")]

        public IActionResult GetPasswordStrengthEvaluationtById(int id)
        {
            var passwordStrengthEvaluation = dbContext.PasswordStrengthEvaluations.Find(id);

            if (passwordStrengthEvaluation is null)
            {
                return NotFound();
            }

            return Ok(passwordStrengthEvaluation);

        }

        [HttpPost]
        public IActionResult AddPasswordStrengthEvaluation(AddPasswordStrengthEvaluationDto addPasswordStrengthEvaluationDto)
        {
            var passwordStrengthEvaluationEntity = new PasswordStrengthEvaluation
            {
                Id = addPasswordStrengthEvaluationDto.Id,
                StrengthLevel = addPasswordStrengthEvaluationDto.StrengthLevel,
                SuggestionMessage = addPasswordStrengthEvaluationDto.SuggestionMessage,
                            
            };

            dbContext.PasswordStrengthEvaluations.Add(passwordStrengthEvaluationEntity);
            dbContext.SaveChanges();

            return Ok(passwordStrengthEvaluationEntity);

        }

        [HttpPut]
        [Route("id{id:int}")]

        public IActionResult UpdatePasswordStrengthEvaluation(UpdatePasswordStrengthEvaluationDto updatePasswordStrengthEvaluationDto, int id)
        {
            var passwordStrengthEvaluation = dbContext.PasswordStrengthEvaluations.Find(id);

            if (passwordStrengthEvaluation is null)
            {
                return NotFound();
            }


            passwordStrengthEvaluation.Id = updatePasswordStrengthEvaluationDto.Id;
            passwordStrengthEvaluation.StrengthLevel = updatePasswordStrengthEvaluationDto.StrengthLevel;
            passwordStrengthEvaluation.SuggestionMessage = updatePasswordStrengthEvaluationDto.SuggestionMessage;




            dbContext.SaveChanges();

            return Ok(passwordStrengthEvaluation);
        }


        [HttpDelete]
        [Route("id{id:int}")]
        public IActionResult DeletePasswordStrengthEvaluation(int id)
        {
            var passwordStrengthEvaluation = dbContext.PasswordStrengthEvaluations.Find(id);

            if (passwordStrengthEvaluation is null)
            {
                NotFound();
            }

            dbContext.PasswordStrengthEvaluations.Remove(passwordStrengthEvaluation);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}