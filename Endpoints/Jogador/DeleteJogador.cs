using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Jogador
{
    [ApiController]
    [Route("api/jogadores")]
    public class DeleteJogador : ControllerBase
    {
        private readonly JogadorService _jogadorService;

        public DeleteJogador(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var jogador = _jogadorService.GetById(id);
            if (jogador == null) return NotFound();

            _jogadorService.Delete(id);
            return NoContent();
        }
    }
}
