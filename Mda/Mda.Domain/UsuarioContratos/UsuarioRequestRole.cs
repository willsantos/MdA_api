using Mda.Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class UsuarioRequestRole
    {
        [Required(ErrorMessage = "Use Usuario ou Administrador para preencher a Role")]
        public EnumAcesso Role { get; set; }
        public Guid Id { get; set; }
    }
}
