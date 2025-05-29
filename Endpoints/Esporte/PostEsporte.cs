using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Esporte
{
    [ApiController]
    [Route("api/esportes")]
    public class PostEsporte : ControllerBase
    {
        private readonly EsporteService _esporteService;

        public PostEsporte(EsporteService esporteService)
        {
            _esporteService = esporteService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] GerenciamentoEsportivoAPI.Models.Esporte esporte)
        {
            _esporteService.Add(esporte);
            return CreatedAtAction(nameof(GetEsportes.GetById), "GetEsportes", new { id = esporte.Id }, esporte);
        }
    }
}
