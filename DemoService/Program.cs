using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DemoService.Data;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// Reduz verbosidade do log para Warning
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Error);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serviços de repositório em memória
builder.Services.AddSingleton<InMemoryDatabase>();

var app = builder.Build();

// Middleware de log de requisição
app.Use(async (context, next) =>
{
    var method = context.Request.Method;
    var path = context.Request.Path;
    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    Console.WriteLine($"[{timestamp}] {method} {path}");
    await next();
});

app.UseSwagger();
app.UseSwaggerUI();

// Exibe no console as URLs do Swagger
var serverAddressesFeature = app.Services.GetService<IServer>()?.Features.Get<IServerAddressesFeature>();
if (serverAddressesFeature != null)
{
    foreach (var address in serverAddressesFeature.Addresses)
    {
        Console.WriteLine($"Swagger disponível em: {address}/swagger");
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
