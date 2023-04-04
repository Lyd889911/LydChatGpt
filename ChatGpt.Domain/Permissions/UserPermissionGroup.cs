using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public class UserPermissionGroup : PermissionGroup
    {
        public UserPermissionGroup(string prefix, UserRole role) : base(prefix, role)
        {
            if (role == UserRole.SuperAdmin)
            {
                _permissions.Add(new Permission(prefix, PermissionItem.Default, "用户管理"));
                _permissions.Add(new Permission(prefix, PermissionItem.Default, "添加用户"));
                _permissions.Add(new Permission(prefix, PermissionItem.Default, "删除用户"));
                _permissions.Add(new Permission(prefix, PermissionItem.Default, "编辑用户"));
            }

        }
    }
}
