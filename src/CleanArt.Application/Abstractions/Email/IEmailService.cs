using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Abstractions.Email
{
    internal interface IEmailService
    {
        Task SendAsync(Domain.Users.Email reciptient,string subject,string body);
    }
}
