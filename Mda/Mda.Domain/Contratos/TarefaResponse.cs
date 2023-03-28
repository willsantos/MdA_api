using Mda.Domain.Entities.Utils;
using Mda.Domain.Entities;

namespace Mda.Domain.Contratos
{
    public class TarefaResponse
    {
        public Guid ProjetoId { get; set; }        
        public EnumStatus StatusTarefa { get; set; }
    }
}
