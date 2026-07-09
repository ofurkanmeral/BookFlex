using CleanArt.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Configurations
{
    internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissions>
    {
        public void Configure(EntityTypeBuilder<RolePermissions> builder)
        {
            builder.ToTable(nameof(RolePermissionConfiguration));
            builder.HasKey(rolePermission => new { rolePermission.RoleId, rolePermission.PermissionId });
            builder.HasData(
                new RolePermissions
                {
                    RoleId = Role.Registered.Id,
                    PermissionId = Permission.userRead.Id
                });
        }
    }
}
