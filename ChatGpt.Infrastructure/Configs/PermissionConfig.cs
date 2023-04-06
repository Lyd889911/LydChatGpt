using ChatGpt.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure.Configs
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission");
        }
    }
}
