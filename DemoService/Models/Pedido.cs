namespace DemoService.Models
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public int RestauranteId { get; set; }
        public string RestauranteNome { get; set; } = string.Empty;
        public List<PratoPedido> Pratos { get; set; } = new();
        public string Status { get; set; } = "Confirmado";
    }

    public class PratoPedido
    {
        public int PratoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
