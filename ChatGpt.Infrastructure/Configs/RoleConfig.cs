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
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");
            builder.HasMany(x => x.RolePermissions).WithOne(x => x.Role);

        }
    }
}
