using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Jogador
{
    [ApiController]
    [Route("api/jogadores")]
    public class GetJogadores : ControllerBase
    {
        private readonly JogadorService _jogadorService;

        public GetJogadores(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jogadores = _jogadorService.GetAll();
            return Ok(jogadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jogador = _jogadorService.GetById(id);
            if (jogador == null) return NotFound();
            return Ok(jogador);
        }
    }
}
