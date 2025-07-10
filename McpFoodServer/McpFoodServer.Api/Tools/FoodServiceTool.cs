using McpFoodServer.Api.Services;
using McpFoodServer.Api.Models;
using System.Threading.Tasks;

using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;


namespace McpFoodServer.Api.Tools
{

    [McpToolType]
    public static class FoodServiceTool
    {
        private static FoodService CreateFoodService()
        {
            var baseUrl = "http://localhost:5000"; // ajuste conforme necessário
            var httpClient = new System.Net.Http.HttpClient();
            return new FoodService(httpClient, baseUrl);
        }

        [McpTool, Description("Obtém os pedidos de um cliente especificado como parâmetro.")]
        public static async Task<string> GetPedidosJsonAsync(string cliente = null)
        {
            var service = CreateFoodService();
            var response = await service.GetPedidosAsync(cliente);
            return await response.Content.ReadAsStringAsync();
        }

        [McpTool, Description("Cria um novo pedido, à partir de uma estrutura Json referente ao pedido, como o exemplo: '{\"cliente\": \"João\",\"restauranteId\": 1,\"pratos\": [1, 2]}'")]
        public static async Task<string> CriarPedidoJsonAsync(PedidoRequest pedido)
        {
            var service = CreateFoodService();
            var response = await service.CriarPedidoAsync(pedido);
            return await response.Content.ReadAsStringAsync();
        }

        [McpTool, Description("Obtém os restaurantes disponíveis, em formato Json, incluindo o tipo de comida do restaurante e sua avaliação.")]
        public static async Task<string> GetRestaurantesJsonAsync()
        {
            var service = CreateFoodService();
            var response = await service.GetRestaurantesAsync();
            return await response.Content.ReadAsStringAsync();
        }

        [McpTool, Description("Obtém o cardápio de um restaurante especificado como parâmetro, em formato Json, incluindo o nome do prato, os ingredientes e o preço.")]
        public static async Task<string> GetCardapioJsonAsync(int restauranteId)
        {
            var service = CreateFoodService();
            var response = await service.GetCardapioAsync(restauranteId);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
