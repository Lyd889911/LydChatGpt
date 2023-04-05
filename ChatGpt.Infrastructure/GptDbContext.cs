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
        public GptDbContext()
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connStr = "Server=localhost;User ID=root;Password=123456;DataBase=gpt;";
        //    optionsBuilder.UseMySql(connStr, new MySqlServerVersion("8.0.30"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载数据库字段配置
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}