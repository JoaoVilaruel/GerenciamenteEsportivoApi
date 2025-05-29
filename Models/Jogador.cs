namespace GerenciamentoEsportivoAPI.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Idade { get; set; }
        public int Camisa { get; set; }
        public double Salario { get; set; }
        public int TimeId { get; set; }
        public int EsporteId { get; set; }
    }
}
