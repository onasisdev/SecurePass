using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public PasswordGeneration PasswordGeneration { get; set; }
        public virtual ICollection<PasswordStrengthEvaluation> PasswordStrengthEvaluations { get; set; } = new List<PasswordStrengthEvaluation>();
    }
}
