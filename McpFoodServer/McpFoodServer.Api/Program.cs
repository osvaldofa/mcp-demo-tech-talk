using System;
using System.Net.Http;
using System.Threading.Tasks;
using McpFoodServer.Api.Services;
using McpFoodServer.Api.Tools;
using McpFoodServer.Api.Models;

using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

class Program
{
    static async Task Main(string[] args)
    {
        /*
        var foodServiceTool = new FoodServiceTool();

        // Exemplo de chamada GET para buscar todos os pedidos (JSON)
        var pedidosJson = await foodServiceTool.GetPedidosJsonAsync("João");
        Console.WriteLine($"Pedidos JSON: {pedidosJson}");

        // Exemplo de chamada GET para buscar restaurantes (JSON)
        var restaurantesJson = await foodServiceTool.GetRestaurantesJsonAsync();
        Console.WriteLine($"Restaurantes JSON: {restaurantesJson}");

        // Exemplo de chamada GET para buscar cardápio de um restaurante (id=1) (JSON)
        var cardapioJson = await foodServiceTool.GetCardapioJsonAsync(1);
        Console.WriteLine($"Cardápio Restaurante 1 JSON: {cardapioJson}");
        */

        var builder = Host.CreateApplicationBuilder(settings: null);

        builder.Services
            .AddMcpServer()
            .WithStdioServerTransport()
            .WithTools();
        await builder.Build().RunAsync();
    }
}
