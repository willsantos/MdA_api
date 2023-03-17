using Mda.Domain.UsuarioContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioRequest, UsuarioResponse> 
    {
        Task<UsuarioResponse> Patch(Guid Id, UsuarioRequestRole Usuario);
    }
}
