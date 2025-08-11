using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordStrengthEvaluation
    {
        public string StrengthLevel { get; set; }
        public string GoodOrBadAspect { get; set; }
        public string SuggestionMessage { get; set; }

        public virtual PasswordGeneration PasswordGeneration { get; set; }
        public virtual User User { get; set; } 
    }
}
