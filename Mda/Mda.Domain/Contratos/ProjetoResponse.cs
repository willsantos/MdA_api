using Mda.Domain.Entities.Utils;
using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Contratos
{
    public class ProjetoResponse
    {
        public Guid ObjetivoId { get; set; }        
        public string Nome { get; set; }
        public DateTime DataAlvo { get; set; }
        public EnumStatus Status { get; set; }
        public float Progresso { get; set; }
    }
}
