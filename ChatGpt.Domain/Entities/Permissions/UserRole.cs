using ChatGpt.Domain.Entities.Users;
using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Permissions
{
    public class UserRole : IHasCreationCreator, IHasModificationCreator
    {
        public Guid? CreatorId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public Guid? ModifierId { get; set; }
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; }
        public User User { get; set; }
        //public Role Role { get; set; }
        private UserRole()
        {

        }
        public UserRole(User user)
        {
            CreationTime = DateTime.Now;
            ModificationTime = DateTime.Now;
            User = user;
            UserId = user.Id;
        }
    }
}
