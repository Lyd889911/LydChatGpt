using ChatGpt.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatGpt.DbMigration
{
    public class DbMigratorHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        public DbMigratorHostedService(IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime)
        {
            _serviceProvider = serviceProvider;
            _hostApplicationLifetime = hostApplicationLifetime;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var dbContext = _serviceProvider.GetRequiredService<GptDbContext>();
            if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                await dbContext.Database.MigrateAsync(); //执行迁移
            }

            _hostApplicationLifetime.StopApplication();
        }
    }
}
