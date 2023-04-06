using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Permissions
{
    public class Role:AggregateRoot
    {
        public string Name { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        public Role(string name)
        {
            this.Name = name;
        }
    }
}
