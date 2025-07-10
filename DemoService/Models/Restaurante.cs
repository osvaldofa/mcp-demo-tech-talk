namespace DemoService.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string TipoComida { get; set; } = string.Empty;
        public List<Prato> Cardapio { get; set; } = new();
        public int QuantidadeAvaliacoes { get; set; }
        public double NotaMedia { get; set; }
    }
}
