using CleanArt.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArt.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Add(User user)
        {
            foreach (var role in user.Roles)
            {
                _context.Attach(role);
            }
            _context.Add(user);
        }
    }
}
