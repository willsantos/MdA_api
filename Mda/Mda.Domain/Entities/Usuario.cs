using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public EnumAcesso Role { get; set; }
    }
}
