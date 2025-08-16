using System;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SecurePass.Application.Dtos;
using SecurePass.Application.Services;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;

namespace SecurePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPasswordController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public UserPasswordController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult GetAllPasswords()
        {
            var passwords = dbContext.PasswordGenerations.ToList();

            var allPasswords = passwords.Select(p => {
                var (strength, suggestions) = EvaluateStrength(p.Password);
                return new
                {
                    id = p.Id,
                    label = p.Label,
                    password = p.Password,
                    strength,
                    suggestions
                };
            }).ToList();

            return Ok(allPasswords);
        }


        [HttpPost]
        public IActionResult AddUserPassword([FromBody] AddUserPasswordDto dto)
        {
            int userId = 1; 

            var passwordEntity = new PasswordGeneration
            {
                Label = dto.Label,
                Password = dto.Password,
                UserId = userId
            };

            dbContext.PasswordGenerations.Add(passwordEntity);
            dbContext.SaveChanges();

            var (strength, suggestions) = EvaluateStrength(dto.Password);

            return Ok(new
            {
                id = passwordEntity.Id,
                label = passwordEntity.Label,
                password = passwordEntity.Password,
                strength,
                suggestions
            });
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUserPassword(int id, [FromBody] AddUserPasswordDto dto)
        {
            var passwordEntity = dbContext.PasswordGenerations.Find(id);
            if (passwordEntity == null)
                return NotFound();

            passwordEntity.Label = dto.Label;
            passwordEntity.Password = dto.Password;
            dbContext.SaveChanges();

            var (strength, suggestions) = EvaluateStrength(dto.Password);

            return Ok(new
            {
                id = passwordEntity.Id,
                label = passwordEntity.Label,
                password = passwordEntity.Password,
                strength,
                suggestions
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserPassword(int id)
        {
            var passwordEntity = dbContext.PasswordGenerations.Find(id);
            if (passwordEntity == null)
                return NotFound();

            dbContext.PasswordGenerations.Remove(passwordEntity);
            dbContext.SaveChanges();

            return Ok();
        }

        private (string strength, string[] suggestions) EvaluateStrength(string password)
        {
            var suggestions = new List<string>();
            int score = 0;
            string strength = "";

            var uppperCaseLetters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            bool hasUppperCaseLetters = uppperCaseLetters.Any(c => password.Contains(c));


            var lowerCaseLetters = "abcdefghijklmnñopqrstuvwxyz";
            bool hasLowerCaseLetters = lowerCaseLetters.Any(c => password.Contains(c));


            var numbers = "0123456789";
            bool hasNumbers = numbers.Any(c => password.Contains(c));


            var specialCharacters = "!@#$%^&*()-_=+[]{}\\)";
            bool hasSpecialCharacters = specialCharacters.Any(c => password.Contains(c));

            var ifHas1234 = "1234";
            bool has1234 = ifHas1234.Any(c => password.Contains(c));

            var abcd = "1234";
            bool hasabcd = abcd.Any(c => password.Contains(c));

            var querty = "1234";
            bool has_querty = querty.Any(c => password.Contains(c));

            if (password.Length < 8)
            {

                suggestions.Add("""

                    La contraseña es demasiado corta.
                    Asegúrate de que tenga al menos 8 
                    caracteres para mayor seguridad
                    
                    """);

                

            }
            else if (password.Length >= 8)
            {
                score += 1;
            }


            if (hasSpecialCharacters == false)
            {
                suggestions.Add("Añade símbolos como @, %, # o & para dificultar que tu contraseña sea adivinada.");

            }
            else
            {
                score += 1;
            }


            if (hasNumbers == false)
            {
                suggestions.Add("Incorpora al menos un número para fortalecer la contraseña.");

            }
            else
            {
                score += 1;
            }


            if (hasUppperCaseLetters == false)
            {
                suggestions.Add("Incluye al menos una letra mayúscula para fortalecer la contraseña.");

            }
            else
            {
                score += 1;
            }


            if (hasLowerCaseLetters == false)
            {
                suggestions.Add("Agrega letras minúsculas para fortalecer la contraseña.");

            }
            else
            {
                score += 1;
            }


            if (has1234 || hasabcd || has_querty)
            {
                suggestions.Add("Evita secuencias predecibles como '1234' o 'abcd'; estas reducen la seguridad de tu contraseña.");

            }
            else if (!has1234 || !hasabcd || !has_querty)
            {
                score += 1;
            }


            if (score <= 2)
            {
                strength = "Nivel de seguridad: Débil";

            }
            else if (score > 2 && score <= 4)
            {
                strength = "Nivel de seguridad: Media";

            }
            else if (score > 4 && score <= 6)
            {
                strength = "Nivel de seguridad: Fuerte";
            }



            if (has1234 || hasabcd || has_querty)
            {
                suggestions.Add("Evita secuencias predecibles como '1234' o 'abcd'; estas reducen la seguridad de tu contraseña.");

            }
            else if (!password.Contains("1234") || !password.Contains("abcd") || !password.Contains("querty"))
            {
                score +=1;
            }

            
            return (strength, suggestions.ToArray());


        }
    }


 

 


       
}




