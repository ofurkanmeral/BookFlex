using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Users
{
    public sealed class RolePermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
