using Microsoft.AspNetCore.Mvc;
using RickMortyZRP.Services;

namespace RickMortyZRP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _service;

        public EpisodesController(IEpisodeService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
        {
            try
            {
                var result = await _service.GetEpisodeWithCharactersAsync(id, ct);
                return Ok(result);
            }
            catch (TaskCanceledException) when (!ct.IsCancellationRequested)
            {
                return StatusCode(504, "Timeout ao consultar a API externa.");
            }
            catch (TaskCanceledException)
            {
                return StatusCode(499, "Request cancelada pelo cliente.");
            }

        }
    }
}
