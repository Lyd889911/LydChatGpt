using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public abstract class PermissionGroup
    {
        private string NamePrefix;
        protected List<Permission> _permissions;
        UserRole Role;
        public PermissionGroup(string prefix,UserRole role)
        {
            NamePrefix = prefix;
            _permissions=new List<Permission>();
        }
        public List<Permission> GetPermissions()
        {
            return _permissions;
        }
    }
}
