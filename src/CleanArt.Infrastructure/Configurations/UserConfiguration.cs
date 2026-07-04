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
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(255)
                .HasConversion(x => x.Value, y => new FirstName(y));

            builder.Property(user => user.LastName)
                .HasMaxLength(255)
                .HasConversion(x=>x.Value, y=>new LastName(y)); 

            builder.Property(user => user.Email)
                .HasMaxLength(256)
                .HasConversion(x=>x.Value , y=>new Domain.Users.Email(y));

            builder.HasIndex(user => user.Email).IsUnique();

            builder.HasIndex(user=>user.IdentityId).IsUnique();
        }
    }
}
