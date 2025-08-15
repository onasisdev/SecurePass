using SecurePass.Applicatio.Services;
using SecurePass.Application.Contracts;
using SecurePass.Application.Dtos;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Infrastructure.Interfaces;


namespace SecurePass.Application.Services
{
    public class PasswordService : IPasswordService  { 

   
        public async Task<string> GeneratePassword(PasswordGenerationDtoForController passwordGenerationDtoForController)
        {

            List<char> characters = new List<char>();



            if (passwordGenerationDtoForController.IncludeSpecialCharacter == true)
            {
                characters.AddRange("!@#$%^&*()-_=+[]{}\\)");
            }

            if (passwordGenerationDtoForController.IncludeNumber == true)
            {
                characters.AddRange("0562819473056281947305");
            }

            if (passwordGenerationDtoForController.IncludeUpperCaseLetter == true)
            {
                characters.AddRange("AFRTHLPOCXEIUMNDGEGKEH");
            }

            if (passwordGenerationDtoForController.IncludeLowerCaseLetter == true)
            {
                characters.AddRange("qwrtypsdfghjklzxcvbnmq");
            }

            var password = new char[passwordGenerationDtoForController.PasswordLength];
            var random = new Random();

            for (int i = 0; i < passwordGenerationDtoForController.PasswordLength; i++)
            {
                password[i] = characters[random.Next(characters.Count)];
            }

            return await Task.FromResult(new string(password));
        }

       


    
      
            public async Task<PasswordStrengthEvaluationDtoForController> EvaluatePasswordStrength(PasswordStrengthEvaluationDtoForController passwordStrengthEvaluationDtoForController, PasswordGenerationDtoForController passwordGenerationDtoForController)
            {
                



                string password = await GeneratePassword(passwordGenerationDtoForController);

                int amountOfCriteriaCompleted = 0;


                if (password.Length < 8)
                {

                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("""

                    La contraseña es demasiado corta.
                    Asegúrate de que tenga al menos 8 
                    caracteres para mayor seguridad
                    
                    """);

                    Console.WriteLine(passwordStrengthEvaluationDtoForController.SuggestionMessage);

                }
                else if (password.Length >= 8)
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (passwordGenerationDtoForController.IncludeSpecialCharacter == false)
                {
                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("Añade símbolos como @, %, # o & para dificultar que tu contraseña sea adivinada.");

                }
                else
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (passwordGenerationDtoForController.IncludeNumber == false)
                {
                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("Incorpora al menos un número para fortalecer la contraseña.");

                }
                else
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (passwordGenerationDtoForController.IncludeUpperCaseLetter == false)
                {
                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("Incluye al menos una letra mayúscula para fortalecer la contraseña.");

                }
                else
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (passwordGenerationDtoForController.IncludeLowerCaseLetter == false)
                {
                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("Agrega letras minúsculas para fortalecer la contraseña.");

                }
                else
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (password.Contains("1234") || password.Contains("abcd") || password.Contains("querty"))
                {
                    passwordStrengthEvaluationDtoForController.SuggestionMessage.Add("Evita secuencias predecibles como '1234' o 'abcd'; estas reducen la seguridad de tu contraseña.");

                }
                else if (!password.Contains("1234") || !password.Contains("abcd") || !password.Contains("querty"))
                {
                    amountOfCriteriaCompleted += 1;
                }


                if (amountOfCriteriaCompleted <= 2)
                {
                    passwordStrengthEvaluationDtoForController.StrengthLevel = "Nivel de seguridad: Débil";

                }
                else if (amountOfCriteriaCompleted > 2 && amountOfCriteriaCompleted <= 4)
                {
                    passwordStrengthEvaluationDtoForController.StrengthLevel = "Nivel de seguridad: Media";

                }
                else if (amountOfCriteriaCompleted > 4 && amountOfCriteriaCompleted <= 6)
                {
                    passwordStrengthEvaluationDtoForController.StrengthLevel = "Nivel de seguridad: Fuerte";
                }


                PasswordStrengthEvaluationDtoForController evaluationResult = new PasswordStrengthEvaluationDtoForController
                {

                    StrengthLevel = passwordStrengthEvaluationDtoForController.StrengthLevel,
                    SuggestionMessage = passwordStrengthEvaluationDtoForController.SuggestionMessage
                };


                return await Task.FromResult(evaluationResult);
            }

        }



}

    

