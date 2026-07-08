using CleanArt.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Authorization
{
    internal sealed partial class AuthorizationService
    {
        private readonly ApplicationDbContext _context;

        public AuthorizationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserRolesResponse>GetRolesForUserAsync(string identityId)
        {
            var roles = await _context.Set<User>()
                .Where(user => user.IdentityId == identityId)
                .Select(user => new UserRolesResponse
                {
                    Id = user.Id,
                    Roles = user.Roles.ToList()
                }).FirstAsync();

            return roles;
        }
    }
}
