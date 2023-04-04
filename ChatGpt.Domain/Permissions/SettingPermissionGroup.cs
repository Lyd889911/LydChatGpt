using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public class SettingPermissionGroup : PermissionGroup
    {
        public SettingPermissionGroup(string prefix, UserRole role) : base(prefix, role)
        {
            _permissions.Add(new Permission(prefix, PermissionItem.Default, "设置"));
            _permissions.Add(new Permission(prefix, PermissionItem.Edit, "修改设置"));
        }
    }
}
