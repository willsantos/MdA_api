using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Entities.Utils
{
    public static class ClaimUtil
    {
        public static string GetClaim(this HttpContext httpContext, string claimTypes)
        {
            var claim = httpContext?.User?.Claims;

            if (claim != null && claim.Any())
                return claim.FirstOrDefault(x => x.Type.Equals(claimTypes)).Value;

            return null;
        }
    }
}
