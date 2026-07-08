using CleanArt.Domain.Users;

namespace CleanArt.Infrastructure.Authorization
{
    internal sealed partial class AuthorizationService
    {
        public sealed class UserRolesResponse
        {
            public Guid Id { get; init; }
            public List<Role> Roles { get; init; } = [];
        }
    }
}
