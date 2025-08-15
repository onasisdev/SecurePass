using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class PasswordStrengthEvaluation
    {
        public int Id { get; set; }
        public string StrengthLevel { get; set; }
        public List<string> SuggestionMessage { get; set; }

        public virtual PasswordGeneration PasswordGeneration { get; set; }
        public int PasswordGenerationId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
