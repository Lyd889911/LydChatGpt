using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public static class PermissionManagement
    {
        public static List<Permission> Permissions(UserRole role)
        {
            List<Permission> list = new List<Permission>();
            var ChatGpt = new ChatGptPermissionGroup("ChatGpt", role);
            var Setting = new SettingPermissionGroup("Setting", role);
            var User = new UserPermissionGroup("User",role);
            list.AddRange(ChatGpt.GetPermissions());
            list.AddRange(Setting.GetPermissions());
            list.AddRange(User.GetPermissions());
            return list;
        }
    }
}
