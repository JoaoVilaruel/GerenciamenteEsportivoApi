using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Time
{
    [ApiController]
    [Route("api/times")]
    public class GetTimes : ControllerBase
    {
        private readonly TimeService _timeService;

        public GetTimes(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var times = _timeService.GetAll();
            return Ok(times);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var time = _timeService.GetById(id);
            if (time == null) return NotFound();
            return Ok(time);
        }
    }
}
