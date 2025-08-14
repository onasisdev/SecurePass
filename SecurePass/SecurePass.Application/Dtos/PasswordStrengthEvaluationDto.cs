using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordStrengthEvaluationDto
    {
        public int Id { get; set; }
        public string StrengthLevel { get; set; }
        public string GoodOrBadAspect { get; set; }
        public string SuggestionMessage { get; set; }

        public virtual PasswordGenerationDto PasswordGeneration { get; set; }
        public virtual UserDto User { get; set; } 
    }
}
