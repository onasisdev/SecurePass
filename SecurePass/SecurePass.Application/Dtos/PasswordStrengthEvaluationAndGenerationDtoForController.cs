using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;

namespace SecurePass.Application.Dtos
{
    public class PasswordStrengthEvaluationAndGenerationDtoForController
    {
        public PasswordGenerationDtoForController PasswordGenerationDtoForController { get; set; }
        public PasswordStrengthEvaluationDtoForController PasswordStrengthEvaluationDtoForController { get; set; }
    }
}
