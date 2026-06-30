using CleanArt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Abstractions.Authentication
{
    public interface IAuthenticationService
    {
        Task<string>RegisterAsync(
            User user,
            string password,
            CancellationToken cancellationToken=default);
    }
}
