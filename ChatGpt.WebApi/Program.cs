using ChatGpt.Domain.DomainServers;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Infrastructure;
using ChatGpt.Infrastructure.Repositorys;
using ChatGpt.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MvcOptions>(x =>
{
    x.Filters.Add<UnitOfWorkFilter>();
});
builder.Services.AddInfrastructure();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
