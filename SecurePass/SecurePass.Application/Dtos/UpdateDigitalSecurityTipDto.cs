using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Application.Dtos
{


    public class UpdateDigitalSecurityTipDto
    {
        public int Id { get; set; }
        public List<string> GoodPractice { get; set; }
        

        public virtual UserDto User { get; set; }
    }
}
