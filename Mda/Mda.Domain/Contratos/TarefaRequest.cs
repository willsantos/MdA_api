using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Contratos
{
    public class TarefaRequest
    {
        [Required(ErrorMessage = "Id do projeto é obrigatório.")]
        public Guid ProjetoId { get; set; }

        [Required(ErrorMessage = "Status da tarefa é obrigatório.")]
        public EnumStatus StatusTarefa { get; set; }
        [Required(ErrorMessage = "Nome da tarefa é obrigatório.")]
        public string Nome { get; set; }
    }
}
