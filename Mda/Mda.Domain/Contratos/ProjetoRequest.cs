using Mda.Domain.Entities.Utils;
using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mda.Domain.Contratos
{
    public class ProjetoRequest
    {
        [Required(ErrorMessage = "Id de Objetivo é obrigatório.")]
        public Guid ObjetivoId { get; set; }

        [Required(ErrorMessage = "Nome do projeto é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data alvo é obrigatório.")]
        public DateTime DataAlvo { get; set; }

        [Required(ErrorMessage = "Status do projeto é obrigatório.")]
        public EnumStatus Status { get; set; }    
    }
}
