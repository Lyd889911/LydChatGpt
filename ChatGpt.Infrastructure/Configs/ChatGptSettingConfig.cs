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
            builder.OwnsOne(x => x.Chat);
            builder.OwnsOne(x => x.Image, x =>
            {
                x.Property(x => x.Size).HasConversion<string>();
            });
        }
    }
}
