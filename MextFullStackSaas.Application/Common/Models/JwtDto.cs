using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Models
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
