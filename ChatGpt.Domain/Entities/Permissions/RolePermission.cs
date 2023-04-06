using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Permissions
{
    public class RolePermission:IHasCreationCreator,IHasModificationCreator
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public Guid? CreatorId{get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public Guid? ModifierId { get; set; }
        public Role Role { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Guid? ParentId { get; set; }
        public string? Icon { get; set; }
        public RolePermission(Role role,Guid permissionid)
        {
            Role = role;
            RoleId = role.Id;
            PermissionId = permissionid;
        }
    }
}
