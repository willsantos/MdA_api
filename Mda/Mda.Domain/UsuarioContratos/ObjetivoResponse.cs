using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class ObjetivoResponse 
    {                
        public Guid AreaId { get; set; }        
        public DateTime DataFinal { get; set; } 
        public string Bloqueios { get; set; } 
        public string Recursos { get; set; }
    }
}
