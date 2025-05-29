using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Time
{
    [ApiController]
    [Route("api/times")]
    public class PostTime : ControllerBase
    {
        private readonly TimeService _timeService;

        public PostTime(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] GerenciamentoEsportivoAPI.Models.Time time)
        {
            _timeService.Add(time);
            return CreatedAtAction(nameof(GetTimes.GetById), "GetTimes", new { id = time.Id }, time);
        }
    }
}
