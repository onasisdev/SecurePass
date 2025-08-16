using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordGeneration
    {
        public int Id { get; set; }
        public int PasswordLength { get; set; }
        public bool IncludeUpperCaseLetter { get; set; }
        public bool IncludeLowerCaseLetter { get; set; }
        public bool IncludeNumber { get; set; }
        public bool IncludeSpecialCharacter { get; set; }
        

        public int UserId { get; set; }

        public string Label { get; set; }
        public string Password { get; set; }


        public virtual ICollection<PasswordStrengthEvaluation> PasswordStrengthEvaluations { get; set; } = new List<PasswordStrengthEvaluation>();



        public virtual User User { get; set; }
    }
}
