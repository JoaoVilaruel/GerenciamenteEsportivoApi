using GerenciamentoEsportivoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEsportivoAPI.Endpoints.Time
{
    [ApiController]
    [Route("api/times")]
    public class DeleteTime : ControllerBase
    {
        private readonly TimeService _timeService;

        public DeleteTime(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var time = _timeService.GetById(id);
            if (time == null) return NotFound();

            _timeService.Delete(id);
            return NoContent();
        }
    }
}
