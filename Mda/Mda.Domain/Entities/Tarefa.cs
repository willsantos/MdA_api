using Mda.Domain.Entities.Utils;


namespace Mda.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public string Nome { get; set; }
        public Guid ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public EnumStatus StatusTarefa { get; set; }
    }
}
