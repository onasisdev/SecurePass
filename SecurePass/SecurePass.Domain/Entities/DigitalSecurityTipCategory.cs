using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Domain.Entities
{
    public class DigitalSecurityTipCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DigitalSecurityTip> DigitalSecurityTips { get; set; } = new List<DigitalSecurityTip>();
    }
}
