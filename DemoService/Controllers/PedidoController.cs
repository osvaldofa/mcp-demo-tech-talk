using DemoService.Data;
using DemoService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly InMemoryDatabase _db;
        public PedidoController(InMemoryDatabase db)
        {
            _db = db;
        }

        // POST: api/pedidos
        [HttpPost]
        public IActionResult FazerPedido([FromBody] PedidoRequest request)
        {
            LogPOST($"<--- Fazendo pedido para o cliente: {request.Cliente}");
            if (string.IsNullOrWhiteSpace(request.Cliente) || request.Pratos == null || !request.Pratos.Any())
                return BadRequest("Cliente, restaurante e pratos são obrigatórios.");

            var restaurante = _db.Restaurantes.FirstOrDefault(r => r.Id == request.RestauranteId);
            if (restaurante == null)
                return BadRequest($"Restaurante com id {request.RestauranteId} não encontrado.");

            var pratosPedidos = new List<PratoPedido>();
            foreach (var pratoId in request.Pratos)
            {
                var prato = restaurante.Cardapio.FirstOrDefault(p => p.Id == pratoId);
                if (prato == null)
                    return BadRequest($"Prato com id {pratoId} não encontrado no restaurante informado.");
                pratosPedidos.Add(new PratoPedido { PratoId = prato.Id, Nome = prato.Nome, Preco = prato.Preco });
            }

            var numero = _db.GerarNumeroPedido();
            var pedido = new Pedido
            {
                Numero = numero,
                Cliente = request.Cliente,
                RestauranteId = restaurante.Id,
                RestauranteNome = restaurante.Nome,
                Pratos = pratosPedidos,
                Status = "Confirmado"
            };
            _db.Pedidos.Add(pedido);
            return Ok(new { NumeroPedido = numero, Status = pedido.Status });
        }

        // GET: api/pedidos?cliente=nome
        [HttpGet]
        public IActionResult ConsultarPedidos([FromQuery] string cliente)
        {
            LogGET($"---> Consultando pedidos para o cliente: {cliente}");
            var pedidos = _db.Pedidos.Where(p => p.Cliente.Equals(cliente, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!pedidos.Any())
                return NotFound();
            return Ok(pedidos);
        }

        public static void LogGET(string texto)
        {
            var corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(texto);
            Console.ForegroundColor = corOriginal;
        }

        public static void LogPOST(string texto)
        {
            var corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(texto);
            Console.ForegroundColor = corOriginal;
        }
    }

    public class PedidoRequest
    {
        public string Cliente { get; set; } = string.Empty;
        public int RestauranteId { get; set; }
        public List<int> Pratos { get; set; } = new();
    }
}
