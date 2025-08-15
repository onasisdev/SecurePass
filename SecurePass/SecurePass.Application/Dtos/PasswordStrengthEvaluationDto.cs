using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurePass.Domain.Entities;

namespace SecurePass.Application.Dtos
{
    public class PasswordStrengthEvaluationDto
    {
        public int Id { get; set; }
        public string StrengthLevel { get; set; }
        public List<string> SuggestionMessage { get; set; }

        public virtual PasswordGenerationDto PasswordGeneration { get; set; }
        public int PasswordGenerationId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
