using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Ativo = true;
            Id = new Guid();
        }
        public bool Ativo { get; set; }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataDelecao { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}
