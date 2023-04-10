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
    public class ChatGptSettingConfig : IEntityTypeConfiguration<ChatGptSetting>
    {
        public void Configure(EntityTypeBuilder<ChatGptSetting> builder)
        {
            builder.ToTable("chatgptsetting");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Chat, x =>
            {
                x.Property(x => x.Temperature).HasMaxLength(2);
            });
            builder.OwnsOne(x => x.Image, x =>
            {
                x.Property(x => x.Size).HasConversion<string>();
            });
            builder.HasQueryFilter(b => b.IsDeleted == false);
        }
    }
}
