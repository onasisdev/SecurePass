using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordGeneration_PasswordStrengthEvaluation
    {
        public int Id { get; set; }
        public int PasswordGenerationId { get; set; }
        public int PasswordStrengthEvaluationId { get;set; }

        public virtual PasswordGeneration PasswordGeneration { get; set; }
        public virtual PasswordStrengthEvaluation PasswordStrengthEvaluation { get; set; }
    }
}
