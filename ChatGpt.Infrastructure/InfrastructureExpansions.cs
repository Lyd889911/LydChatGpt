using ChatGpt.Domain;
using ChatGpt.Domain.DomainServers;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure
{
    public static class InfrastructureExpansions
    {
        /// <summary>
        /// 文件服务的一些注册
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<GptDbContext>(opt =>
            {
                string connStr = "Server=localhost;User ID=root;Password=123456;DataBase=gpt;";
                opt.UseMySql(connStr, new MySqlServerVersion("8.0.30"));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatGptSettingRepository, ChatGptSettingRepository>();
            services.AddScoped<UserDomainServer>();
            services.AddScoped<SettingDemainServer>();
            services.AddScoped<IStorageClient, AvatarStorageClient>();
            return services;
        }
    }
}
