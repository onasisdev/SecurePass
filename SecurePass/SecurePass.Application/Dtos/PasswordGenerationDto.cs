using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordGenerationDto
    {
        public int Id { get; set; }
        public int PasswordLength { get; set; }
        public bool IncludeUpperCaseLetter { get; set; }
        public bool IncludeLowerCaseLetter { get; set; }
        public bool IncludeNumber { get; set; }
        public bool IncludeSpecialCharacter { get; set; }

        public virtual ICollection<PasswordStrengthEvaluationDto> PasswordStrengthEvaluations { get; set; } = new List<PasswordStrengthEvaluationDto>();

        public virtual UserDto User { get; set; }
    }
}
