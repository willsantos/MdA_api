using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Area : BaseEntity
    {
        public int Tipo { get; set; } // defino smallInt nas configs do Sql, certo?
    }
}
