using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using McpFoodServer.Api.Models;

namespace McpFoodServer.Api.Services
{
    public class FoodService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public FoodService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl.TrimEnd('/');
        }

        // GET /api/Pedido?cliente=...
        public async Task<HttpResponseMessage> GetPedidosAsync(string cliente = null)
        {
            var url = string.IsNullOrEmpty(cliente) ? $"{_baseUrl}/api/Pedido" : $"{_baseUrl}/api/Pedido?cliente={cliente}";
            return await _httpClient.GetAsync(url);
        }

        // POST /api/Pedido
        public async Task<HttpResponseMessage> CriarPedidoAsync(PedidoRequest pedido)
        {
            var url = $"{_baseUrl}/api/Pedido";
            return await _httpClient.PostAsJsonAsync(url, pedido);
        }

        // GET /api/Restaurante
        public async Task<HttpResponseMessage> GetRestaurantesAsync()
        {
            var url = $"{_baseUrl}/api/Restaurante";
            return await _httpClient.GetAsync(url);
        }

        // GET /api/Restaurante/{id}/cardapio
        public async Task<HttpResponseMessage> GetCardapioAsync(int restauranteId)
        {
            var url = $"{_baseUrl}/api/Restaurante/{restauranteId}/cardapio";
            return await _httpClient.GetAsync(url);
        }
    }
}
