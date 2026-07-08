using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Authentication
{
    internal static class ClaimsPrincipalExtensions
    {
        public static string? GetIdentityId(this ClaimsPrincipal? principal)
        {
            return principal?.FindFirstValue(ClaimTypes.NameIdentifier ?? throw new ApplicationException("User identity is univable"));
        }
    }
}
