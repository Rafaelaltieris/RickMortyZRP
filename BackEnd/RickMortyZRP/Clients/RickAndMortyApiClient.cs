using RickMortyZRP.Models.External;
using System.Net;
using System.Text.Json;

namespace RickMortyZRP.Clients
{
    public class RickMortyApiClient : IRickMortyApiClient
    {
        private readonly HttpClient _http;
        private static readonly JsonSerializerOptions JsonOpts = new() { PropertyNameCaseInsensitive = true };

        public RickMortyApiClient(HttpClient http) => _http = http;

        public async Task<EpisodeDto?> GetEpisodeAsync(int id, CancellationToken ct)
        {
            var resp = await _http.GetAsync($"episode/{id}", ct);
            if (resp.StatusCode == HttpStatusCode.NotFound) return null;

            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<EpisodeDto>(json, JsonOpts);
        }

        public async Task<List<CharacterDto>> GetCharactersByIdsAsync(string[] ids, CancellationToken ct)
        {
            var path = "character/" + string.Join(",", ids);

            var resp = await _http.GetAsync(path, ct);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync(ct);

            if (json.TrimStart().StartsWith("["))
                return JsonSerializer.Deserialize<List<CharacterDto>>(json, JsonOpts) ?? [];

            var single = JsonSerializer.Deserialize<CharacterDto>(json, JsonOpts);
            return single is null ? [] : [single];
        }
    }
}
