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
            var result = await _service.GetEpisodeWithCharactersAsync(id, ct);
            if (result is null) return NotFound(new { message = "Episode not found" });

            return Ok(result);
        }
    }
}
