namespace RickMortyZRP.Models.Api
{
    public class CharacterResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public string Species { get; set; } = "";
        public string Image { get; set; } = "";
    }
}