using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class UsuarioResponse 
    {
        public bool Ativo { get; set; }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
