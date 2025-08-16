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
    public class PasswordGenerationController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public PasswordGenerationController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPasswordGenerations()
        {
            var allPasswordGenerations = dbContext.PasswordGenerations.ToList();

            return Ok(allPasswordGenerations);
        }

        [HttpGet]
        [Route("id{id:int}")]

        public IActionResult GetPasswordGenerationtById(int id)
        {
            var passwordGeneration = dbContext.PasswordGenerations.Find(id);

            if (passwordGeneration is null)
            {
                return NotFound();
            }

            return Ok(passwordGeneration);

        }

        [HttpPost]
        public IActionResult AddPasswordGeneration(AddPasswordGenerationDto addPasswordGenerationDto)
        {
            var passwordGenerationEntity = new PasswordGeneration
            {
                Id = addPasswordGenerationDto.Id,
                IncludeUpperCaseLetter = addPasswordGenerationDto.IncludeUpperCaseLetter,
                IncludeLowerCaseLetter = addPasswordGenerationDto.IncludeLowerCaseLetter,
                IncludeNumber = addPasswordGenerationDto.IncludeNumber,
                IncludeSpecialCharacter = addPasswordGenerationDto.IncludeSpecialCharacter,
                UserId = addPasswordGenerationDto.UserId

            };

            dbContext.PasswordGenerations.Add(passwordGenerationEntity);
            dbContext.SaveChanges();

            return Ok(passwordGenerationEntity);

        }

        [HttpPut]
        [Route("id{id:int}")]

        public IActionResult UpdatePasswordGeneration(UpdatePasswordGenerationDto updatePasswordGenerationDto, int id)
        {
            var passwordGeneration = dbContext.PasswordGenerations.Find(id);

            if (passwordGeneration is null)
            {
                return NotFound();
            }


            passwordGeneration.Id = updatePasswordGenerationDto.Id;
            passwordGeneration.IncludeUpperCaseLetter = updatePasswordGenerationDto.IncludeUpperCaseLetter;
            passwordGeneration.IncludeLowerCaseLetter = updatePasswordGenerationDto.IncludeLowerCaseLetter;
            passwordGeneration.IncludeNumber = updatePasswordGenerationDto.IncludeNumber;
            passwordGeneration.IncludeSpecialCharacter = updatePasswordGenerationDto.IncludeSpecialCharacter;
            passwordGeneration.UserId = updatePasswordGenerationDto.UserId;


            dbContext.SaveChanges();

            return Ok(passwordGeneration);
        }


        [HttpDelete]
        [Route("id{id:int}")]
        public IActionResult DeletePasswordGeneration(int id)
        {
            var passwordGeneration = dbContext.PasswordGenerations.Find(id);

            if (passwordGeneration is null)
            {
                NotFound();
            }

            dbContext.PasswordGenerations.Remove(passwordGeneration);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}