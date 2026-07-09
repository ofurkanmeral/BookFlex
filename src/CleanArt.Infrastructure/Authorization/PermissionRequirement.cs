using Microsoft.AspNetCore.Authorization;

namespace CleanArt.Infrastructure.Authorization
{
    internal sealed class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
