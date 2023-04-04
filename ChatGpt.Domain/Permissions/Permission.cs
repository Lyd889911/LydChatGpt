using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public class Permission
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Permission(string prefix, PermissionItem name, string? description)
        {
            Name = prefix +":"+ nameof(name);
            Description = description;
        }
    }
}
