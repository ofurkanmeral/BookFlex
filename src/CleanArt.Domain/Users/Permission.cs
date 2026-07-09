using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Users
{
    public sealed class Permission
    {
        public static readonly Permission userRead = new(1, "users:read");
        public Permission(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; init; }
        public string Name { get; init; }   
    }
}
