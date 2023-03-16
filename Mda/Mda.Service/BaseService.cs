using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Service
{
    public class BaseService
    {
        public readonly Guid? UsuarioId;
        private IHttpContextAccessor httpContextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
        {
            //UsuarioId = httpContextAccessor.HttpContext.GetClaim(ClaimTypes.NameIdentifier).ToInt();            
        }
    }
}
