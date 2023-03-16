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
        }
        public bool Ativo { get; set; }
        public Guid Id = new Guid();
    }
}
