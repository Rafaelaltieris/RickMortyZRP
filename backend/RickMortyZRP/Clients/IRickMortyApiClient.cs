using RickMortyZRP.Models.External;

namespace RickMortyZRP.Clients
{
    public interface IRickMortyApiClient
    {
        Task<EpisodeDto?> GetEpisodeAsync(int id, CancellationToken ct);
        Task<List<CharacterDto>> GetCharactersByIdsAsync(string[] ids, CancellationToken ct);
    }
}
