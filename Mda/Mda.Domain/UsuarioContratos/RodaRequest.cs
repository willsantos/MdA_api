using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class RodaRequest
    {
        [Required(ErrorMessage = "Tipo é obrigatório.")]
        public TipoArea Tipo { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório.")]
        public DateTime Ano { get; set; }
    }
}
