﻿using Mda.Domain.Entities.Utils;
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
        public readonly string? UsuarioId; // precisamos converter o Guid para string para acontecer a verificação?
        private IHttpContextAccessor httpContextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
        {            
            var IdGuid = httpContextAccessor.HttpContext.GetClaim(ClaimTypes.NameIdentifier);
            var UsuarioId = new Guid(IdGuid);
        }
    }
}
