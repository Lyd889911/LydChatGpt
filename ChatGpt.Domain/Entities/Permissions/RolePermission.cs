using ChatGpt.Domain.Entities.Users;
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
        //public Role Role { get; set; }
        public Permission Permission { get; set; }
        public RolePermission(Permission permission)
        {
            Permission = permission;
            PermissionId = permission.Id;
            CreationTime=DateTime.Now;
            ModificationTime=DateTime.Now;
        }
    }
}
