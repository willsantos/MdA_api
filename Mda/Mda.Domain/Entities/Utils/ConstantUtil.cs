using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities.Utils
{
    public static class ConstantUtil
    {
        public const string PerfilUsuarioAdmin = "Administrador";
        public const string PerfilUsuario = "Usuario";
        public const string PerfilLogadoNome = $"{PerfilUsuarioAdmin}, {PerfilUsuario}";
    }
}
