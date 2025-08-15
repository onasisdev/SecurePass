using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Application.Dtos
{
    public class PasswordGenerationDtoForController
    {
        public int Id { get; set; }
        public int PasswordLength { get; set; }
        public bool IncludeUpperCaseLetter { get; set; }
        public bool IncludeLowerCaseLetter { get; set; }
        public bool IncludeNumber { get; set; }
        public bool IncludeSpecialCharacter { get; set; }
        public int UserId { get; set; }
    }
}
