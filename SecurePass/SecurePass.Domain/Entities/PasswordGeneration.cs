using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordGeneration
    {
        public int PasswordLength { get; set; }
        public bool IncludeUpperCaseLetters { get; set; }
        public bool IncludeLowerCaseLetters { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        
        public virtual ICollection<PasswordStrengthEvaluation> PasswordStrengthEvaluations { get; set; } = new List<PasswordStrengthEvaluation>();

        public virtual User User { get; set; }
    }
}
