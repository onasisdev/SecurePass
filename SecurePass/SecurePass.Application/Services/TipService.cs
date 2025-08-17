using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SecurePass.Application.Contracts;
using SecurePass.Application.Dtos;

namespace SecurePass.Application.Services
{
    public class TipService : ITipService
    {
        public async Task<DigitalSecurityTipDtoForController> AddDigitalSecurityTip(DigitalSecurityTipDtoForController digitalSecurityTipDtoForController)
        {
            Console.WriteLine("Seguridad de Contraseñas:" + "\n");

            digitalSecurityTipDtoForController.GoodPractice.Add("Usar contraseñas largas y únicas: Combina mayúsculas, minúsculas, números y símbolos." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("No repitir contraseñas: Una misma clave en varias cuentas aumenta el riesgo si una se filtra." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("Actualizar tus contraseñas regularmente: Especialmente en servicios críticos como correo, bancos o redes sociales." + "\n");

            DigitalSecurityTipDtoForController digitalSecurityTipResult = new DigitalSecurityTipDtoForController
            {

                GoodPractice = digitalSecurityTipDtoForController.GoodPractice
                
            };

            return await Task.FromResult(digitalSecurityTipResult);
        }

        public async Task<DigitalSecurityTipCategoryDto> AddDigitalSecurityTipCategory(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto)
        {
            Console.WriteLine("Autenticación y Acceso: " + "\n");

            digitalSecurityTipCategoryDto.Name.Add("Autenticación y Acceso: " + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Activa la autenticación en dos pasos (2FA): Incluso si tu contraseña se ve comprometida, tu cuenta estará protegida." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("No compartas tus contraseñas: Ni por correo, ni por chat, ni en capturas de pantalla." + "\n");

            
            digitalSecurityTipCategoryDto.Name.Add("Prevención de Amenazas: " + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Desconfía de enlaces sospechosos: El phishing es una de las formas más comunes de robo de cuentas." + "\n");
            
            
            digitalSecurityTipCategoryDto.Name.Add("Herramientas y Buenas Prácticas: " + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Utiliza un gestor de contraseñas: Te ayuda a recordar claves seguras sin tener que memorizarlas todas." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Mantén tu dispositivo seguro: Instala actualizaciones, usa antivirus y bloquea la pantalla." + "\n");
            

            DigitalSecurityTipCategoryDto digitalSecurityTipCategoryResult = new DigitalSecurityTipCategoryDto
            {

                Name = digitalSecurityTipCategoryDto.Name,
                Description = digitalSecurityTipCategoryDto.Description,


            };

            return await Task.FromResult(digitalSecurityTipCategoryResult);
        }
    }
}
