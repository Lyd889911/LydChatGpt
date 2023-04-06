using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Permissions
{
    public class Permission:AggregateRoot
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Guid? ParentId { get; set; }
        public string? Icon { get; set; }
        public Permission(string name,string description,string path,Guid parentid,string icon)
        {
            this.Name = name;
            this.Description = description;
            this.Path = path;
            this.ParentId = parentid;
            this.Icon = icon;
        }
    }
}
