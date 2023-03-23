using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Area : BaseEntity
    {
        public string NomeArea { get; set; }
        public Guid RodaId { get; set; }
        public Roda Roda { get; set; }
        public int NotaInicio { get; set; }
        public int NotaFim { get; set; }
        public int Ano { get; set; }
        public virtual ICollection<Objetivo> Objetivos { get; set; }

    }
}
