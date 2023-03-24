using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class AreaRequestFim
    {
        [Required(ErrorMessage = "Nota Fim é obrigatória.")]
        public int NotaFim { get; set; }
    }
}
