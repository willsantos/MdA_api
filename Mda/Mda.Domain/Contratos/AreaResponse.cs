using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class AreaResponse 
    {
        public string NomeArea { get; set; }
        public Guid RodaId { get; set; }
        public virtual Roda Roda { get; set; }
        public int NotaInicio { get; set; }
        public int? NotaFim { get; set; }
        public int Ano { get; set; }
    }
}
