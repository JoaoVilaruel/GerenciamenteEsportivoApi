using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Esporte
{
    [ApiController]
    [Route("api/esportes")]
    public class GetEsportes : ControllerBase
    {
        private readonly EsporteService _esporteService;

        public GetEsportes(EsporteService esporteService)
        {
            _esporteService = esporteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var esportes = _esporteService.GetAll();
            return Ok(esportes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var esporte = _esporteService.GetById(id);
            if (esporte == null) return NotFound();
            return Ok(esporte);
        }
    }
}
