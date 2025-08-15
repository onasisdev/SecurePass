using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Application.Contracts;
using SecurePass.Application.Dtos;

namespace SecurePass.Application.Services
{
    public class TipService : ITipService
    {
        public async Task<DigitalSecurityTipDtoForController> AddDigitalSecurityTip(DigitalSecurityTipDtoForController digitalSecurityTipDtoForController)
        {
            Console.WriteLine("1. Buenas prácticas en la creación y manejo de contraseñas:" + "\n");

            digitalSecurityTipDtoForController.GoodPractice.Add("Utilizar combinaciones de letras mayúsculas, minúsculas, números y caracteres especiales." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("Evitar información personal predecible (fechas de nacimiento, nombres, direcciones)." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("No reutilizar contraseñas en diferentes cuentas o servicios." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("Cambiar las contraseñas periódicamente, especialmente si hay sospecha de filtración." + "\n");
            digitalSecurityTipDtoForController.GoodPractice.Add("Usar frases o secuencias largas y fáciles de recordar pero difíciles de adivinar." + "\n");

            DigitalSecurityTipDtoForController digitalSecurityTipResult = new DigitalSecurityTipDtoForController
            {

                GoodPractice = digitalSecurityTipDtoForController.GoodPractice
                
            };

            return await Task.FromResult(digitalSecurityTipResult);
        }

        public async Task<DigitalSecurityTipCategoryDto> AddDigitalSecurityTipCategory(DigitalSecurityTipCategoryDto digitalSecurityTipCategoryDto)
        {
            Console.WriteLine("2. Clasificación de los tips por categorías:" + "\n");

            digitalSecurityTipCategoryDto.Name.Add("Creación de contraseñas" + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Generar contraseñas de al menos 12 caracteres." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Evitar patrones comunes como '123456' o 'qwerty'." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Combinar caracteres aleatorios para aumentar la entropía." + "\n");

            
            digitalSecurityTipCategoryDto.Name.Add("Gestión de cuentas" + "\n");
            digitalSecurityTipCategoryDto.Description.Add("No compartir contraseñas con terceros." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Utilizar administradores de contraseñas para almacenar y organizar credenciales." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Habilitar la autenticación multifactor (MFA) siempre que sea posible.");

            
            digitalSecurityTipCategoryDto.Name.Add("Seguridad en línea" + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Evitar iniciar sesión en redes Wi-Fi públicas sin protección." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Cerrar sesión en dispositivos compartidos o públicos." + "\n");
            digitalSecurityTipCategoryDto.Description.Add("Mantener el software y los navegadores actualizados para prevenir vulnerabilidades.");

            DigitalSecurityTipCategoryDto digitalSecurityTipCategoryResult = new DigitalSecurityTipCategoryDto
            {

                Name = digitalSecurityTipCategoryDto.Name,
                Description = digitalSecurityTipCategoryDto.Description,


            };

            return await Task.FromResult(digitalSecurityTipCategoryResult);
        }
    }
}
