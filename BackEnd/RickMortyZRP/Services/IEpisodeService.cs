using RickMortyZRP.Models.Api;

namespace RickMortyZRP.Services
{
    public interface IEpisodeService
    {
        Task<EpisodeResponse?> GetEpisodeWithCharactersAsync(int episodeId, CancellationToken ct);
    }
}
