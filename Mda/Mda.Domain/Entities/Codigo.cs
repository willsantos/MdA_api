using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Codigo
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CodigoResgate { get; set; }
        public DateTime GeradoEm { get; set; }
    }
}
