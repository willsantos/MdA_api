using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class AreaRequestInicio
    {
        [Required(ErrorMessage = "Nome da Area é obrigatório.")]
        public string NomeArea { get; set; }

        [Required(ErrorMessage = "Id Roda é obrigatório.")]
        public Guid RodaId { get; set; }
        [Required(ErrorMessage = "Nota Inicial é obrigatório.")]
        public int NotaInicio { get; set; }       

        [Required(ErrorMessage = "Ano é obrigatório.")]
        public int Ano { get; set; }
    }
}
