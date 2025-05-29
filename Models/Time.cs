using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int AnoFundacao { get; set; }
        public int QtdTitulos { get; set; }
        public List<string> Titulos { get; set; } = new List<string>();
        public int EsporteId { get; set; }
    }
}
