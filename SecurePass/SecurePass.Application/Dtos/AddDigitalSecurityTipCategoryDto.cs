using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Application.Dtos
{
    public class AddDigitalSecurityTipCategoryDto
    {
        public int Id { get; set; }
        public List<string> Name { get; set; }
        public List<string> Description { get; set; }
    }
}
