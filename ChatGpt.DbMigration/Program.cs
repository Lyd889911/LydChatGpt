using ChatGpt.DbMigration;
using ChatGpt.Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructure();
        //services.AddHostedService<DbMigratorHostedService>();
    })
    .Build();

await host.RunAsync();
