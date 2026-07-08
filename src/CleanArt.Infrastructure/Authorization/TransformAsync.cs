using CleanArt.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CleanArt.Infrastructure.Authorization
{
    internal sealed class TransformAsync : IClaimsTransformation
    {
        private IServiceProvider _serviceProvider;

        public TransformAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        async Task<ClaimsPrincipal> IClaimsTransformation.TransformAsync(ClaimsPrincipal principal)
        {
            if(principal.HasClaim(claim=>claim.Type==ClaimTypes.Role)&&
                principal.HasClaim(claim => claim.Type == JwtRegisteredClaimNames.Sub))
            {
                return principal;
            }
            using var scope = _serviceProvider.CreateScope();
            var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();
            var identityId = principal.GetIdentityId();
            var userRoles=await authorizationService.GetRolesForUserAsync(identityId);
            var claimIdentity = new ClaimsIdentity();
            claimIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,userRoles.Id.ToString()));

            foreach (var role in userRoles.Roles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }
            principal.AddIdentity(claimIdentity);
            return principal;
        }
    }
}
