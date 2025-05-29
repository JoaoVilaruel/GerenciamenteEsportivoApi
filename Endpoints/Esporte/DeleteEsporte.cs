using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Esporte
{
    [ApiController]
    [Route("api/esportes")]
    public class DeleteEsporte : ControllerBase
    {
        private readonly EsporteService _esporteService;

        public DeleteEsporte(EsporteService esporteService)
        {
            _esporteService = esporteService;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var esporte = _esporteService.GetById(id);
            if (esporte == null) return NotFound();

            _esporteService.Delete(id);
            return NoContent();
        }
    }
}
