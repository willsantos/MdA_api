﻿using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities
{
    public class Roda : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime Ano { get; set; }
        public TipoArea Tipo { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}
