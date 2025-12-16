namespace RickMortyZRP.Models.Api
{
    public class EpisodeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string AirDate { get; set; } = "";
        public string EpisodeCode { get; set; } = "";
        public string SourceSystem { get; set; } = "RickAndMorty";
        public List<CharacterResponse> Characters { get; set; } = [];
    }
}
