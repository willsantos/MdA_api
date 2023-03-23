using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Objetivo : BaseEntity
    {
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }
        public DateTime DataFinal { get; set; }
        public string Bloqueios { get; set; }
        public string Recursos { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }

    }
}
