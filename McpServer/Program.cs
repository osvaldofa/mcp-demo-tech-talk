using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(settings: null);

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools();
await builder.Build().RunAsync();


[McpToolType]
public static class RestaurantMcpServer
{
    [McpTool, Description("Get the menu options for the DEMO restaurant.")]
    public static string GetMenuOptions()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menu", "menu.json");
        return File.ReadAllText(filePath);
    }
}

