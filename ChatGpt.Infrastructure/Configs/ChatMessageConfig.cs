using ChatGpt.Domain.Entities.Chats.ChatGpt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure.Configs
{
    public class ChatMessageConfig : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("chatmessage");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserId);
            builder.HasQueryFilter(b => b.IsDeleted == false);
        }
    }
}
