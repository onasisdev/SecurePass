using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{


    public class DigitalSecurityTip
    {
        public int Id { get; set; }
        public List<string> GoodPractice { get; set; }

        public virtual User User { get; set; }

        public virtual DigitalSecurityTipCategory DigitalSecurityTipCategory { get; set; }
    }
}
