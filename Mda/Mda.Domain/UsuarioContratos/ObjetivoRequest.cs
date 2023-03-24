using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class ObjetivoRequest
    {
        [Required(ErrorMessage = "Nome Objetivo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Id de AREA é obrigatório")]
        public Guid AreaId { get; set; }

        [Required(ErrorMessage = "Data final é obrigatório")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "Bloqueios é obrigatório")]
        public string Bloqueios { get; set; }

        [Required(ErrorMessage = "Recursos é obrigatório")]
        public string Recursos { get; set; }
    }
}
