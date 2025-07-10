using DemoService.Data;
using DemoService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly InMemoryDatabase _db;
        public RestauranteController(InMemoryDatabase db)
        {
            _db = db;
        }

        // GET: api/restaurantes
        [HttpGet]
        public IActionResult GetRestaurantes()
        {
            LogGET($"---> Consultando restaurantes");
            var lista = _db.Restaurantes.Select(r => new
            {
                r.Id,
                r.Nome,
                r.TipoComida,
                r.QuantidadeAvaliacoes,
                r.NotaMedia
            });
            return Ok(lista);
        }

        // GET: api/restaurantes/{id}/cardapio
        [HttpGet("{id}/cardapio")]
        public IActionResult GetCardapio(int id)
        {
            LogGET($"---> Consultando cardápio do restaurante: {id}");
            var restaurante = _db.Restaurantes.FirstOrDefault(r => r.Id == id);
            if (restaurante == null) return NotFound();
            var cardapioOrganizado = restaurante.Cardapio
                .GroupBy(p => p.Categoria)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(p => new
                    {
                        p.Id,
                        p.Nome,
                        Ingredientes = p.Ingredientes.Select(i => new { i.Nome, i.Alergenico }),
                        p.Preco
                    })
                );
            return Ok(cardapioOrganizado);
        }

        public static void LogGET(string texto)
        { 
            var corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(texto); 
            Console.ForegroundColor = corOriginal;
        }
    }
}
