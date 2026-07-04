using CleanArt.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Users.Exceptions
{
    public static class UserErrors
    {
        public static Error CredentialNotFound = new Error(
            "User.CredentialNotFound",
            "The user not found ");
    }
}
