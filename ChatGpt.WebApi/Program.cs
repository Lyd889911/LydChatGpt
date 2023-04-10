using ChatGpt.Domain.DomainServers;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Infrastructure;
using ChatGpt.Infrastructure.Repositorys;
using ChatGpt.WebApi;
using ChatGpt.WebApi.Filters;
using ChatGpt.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<Jwt>();
builder.Services.AddControllers();
builder.Services.Configure<MvcOptions>(x =>
{
    x.Filters.Add<UnitOfWorkFilter>();
});
builder.Services.AddInfrastructure();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(jwtoption =>
{
    string SigningKey = builder.Configuration.GetValue<string>("SecurityKey");
    byte[] keyBytes = Encoding.UTF8.GetBytes(SigningKey);
    var secKey = new SymmetricSecurityKey(keyBytes);
    jwtoption.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secKey
    };
});

//#region ½ûÖ¹Ä¬ÈÏÐÐÎª
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.InvalidModelStateResponseFactory = (context) =>
//    {
//        if (context.ModelState.IsValid)
//            return null;
//        var error = "";
//        foreach (var item in context.ModelState)
//        {
//            var state = item.Value;
//            var message = state.Errors.FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.ErrorMessage))?.ErrorMessage;
//            if (string.IsNullOrWhiteSpace(message))
//            {
//                message = state.Errors.FirstOrDefault(o => o.Exception != null)?.Exception.Message;
//            }
//            if (string.IsNullOrWhiteSpace(message))
//                continue;
//            error = message;
//            break;
//        }
//        return new ObjectResult(new ResultDto(400,error.ToString(),null));
//    };
//});
//#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ResponseMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
