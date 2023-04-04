using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Entities.Users.ChatGpt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id).HasName("user_pk_id");
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x=>x.PasswordHash).HasMaxLength(100);
            builder.HasIndex(x => x.UserName).HasDatabaseName("user_idx_username");
            builder.HasOne(x => x.ChatGptSetting).WithOne(x => x.User);
            builder.Property(x => x.Role).HasConversion<string>();
        }
    }
}
