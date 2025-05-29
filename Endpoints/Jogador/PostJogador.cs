using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Jogador
{
    [ApiController]
    [Route("api/jogadores")]
    public class PostJogador : ControllerBase
    {
        private readonly JogadorService _jogadorService;

        public PostJogador(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] GerenciamentoEsportivoAPI.Models.Jogador jogador)
        {
            _jogadorService.Add(jogador);
            return CreatedAtAction(nameof(GetJogadores.GetById), "GetJogadores", new { id = jogador.Id }, jogador);
        }
    }
}
