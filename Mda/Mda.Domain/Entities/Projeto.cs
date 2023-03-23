using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Projeto : BaseEntity
    {
        public Guid ObjetivoId { get; set; }
        public virtual Objetivo Objetivo { get; set; }
        public string Nome { get; set; }
        public DateTime DataAlvo { get; set; }
        public EnumStatus Status { get; set; }
        public float Progresso { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
