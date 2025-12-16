export type Character = {
  id: number;
  name: string;
  status: string;
  species: string;
  image: string;
};

export type EpisodeResponse = {
  id: number;
  name: string;
  airDate: string;
  episodeCode: string;
  sourceSystem: string;
  characters: Character[];
};