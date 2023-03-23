using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public Guid ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public EnumStatus StatusTarefa { get; set; }
    }
}
