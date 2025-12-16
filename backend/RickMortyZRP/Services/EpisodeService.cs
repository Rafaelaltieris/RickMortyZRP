    using RickMortyZRP.Clients;
using RickMortyZRP.Models.Api;

namespace RickMortyZRP.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IRickMortyApiClient _client;

        public EpisodeService(IRickMortyApiClient client)
        {
            _client = client;
        }

        public async Task<EpisodeResponse?> GetEpisodeWithCharactersAsync(int episodeId, CancellationToken ct)
        {
            var episode = await _client.GetEpisodeAsync(episodeId, ct);
            if (episode is null) return null;

            var ids = episode.Characters
                .Select(url => url.Split('/').Last())
                .Where(x => int.TryParse(x, out _))
                .ToArray();

            var characters = ids.Length == 0
                ? []
                : await _client.GetCharactersByIdsAsync(ids, ct);

            var orderedCharacters = characters
                .OrderBy(c => c.Name, StringComparer.OrdinalIgnoreCase)
                .ThenBy(c => c.Id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    Species = c.Species,
                    Image = c.Image
                })
                .ToList();

            return new EpisodeResponse
            {
                Id = episode.Id,
                Name = episode.Name,
                AirDate = episode.AirDate,
                EpisodeCode = episode.Episode,
                SourceSystem = "RickAndMorty",
                Characters = orderedCharacters
            };
        }
    }
}