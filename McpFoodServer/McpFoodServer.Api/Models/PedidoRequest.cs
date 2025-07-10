namespace McpFoodServer.Api.Models
{
    public class PedidoRequest
    {
        public string? Cliente { get; set; }
        public int RestauranteId { get; set; }
        public List<int>? Pratos { get; set; }
    }
}
