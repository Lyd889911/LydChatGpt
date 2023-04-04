using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Permissions
{
    public class ChatGptPermissionGroup : PermissionGroup
    {
        public ChatGptPermissionGroup(string prefix, UserRole role) : base(prefix, role)
        {
            _permissions.Add(new Permission(prefix, PermissionItem.Default, "ChatGpt"));
            _permissions.Add(new Permission(prefix, PermissionItem.Creation, "提问"));
        }
    }
}
