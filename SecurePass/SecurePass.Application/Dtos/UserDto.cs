using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class UserDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public PasswordGenerationDto PasswordGeneration { get; set; }
        public virtual ICollection<PasswordStrengthEvaluationDto> PasswordStrengthEvaluations { get; set; } = new List<PasswordStrengthEvaluationDto>();
    }
}
