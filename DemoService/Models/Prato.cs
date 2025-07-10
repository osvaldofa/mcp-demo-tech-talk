namespace DemoService.Models
{
    public class Prato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty; // Entrada, Principal, Sobremesa
        public List<Ingrediente> Ingredientes { get; set; } = new();
        public decimal Preco { get; set; }
    }

    public class Ingrediente
    {
        public string Nome { get; set; } = string.Empty;
        public bool Alergenico { get; set; } = false;
    }
}
