using ChatGpt.Domain.Entities.Chats.ChatGpt;
using ChatGpt.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatGpt.Infrastructure
{
    public class GptDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public GptDbContext(DbContextOptions<GptDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载数据库字段配置
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}