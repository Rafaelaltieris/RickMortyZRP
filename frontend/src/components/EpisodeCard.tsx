import type { EpisodeResponse } from "../types/api";
import { CharacterItem } from "./CharacterItem";

export function EpisodeCard({ episode }: { episode: EpisodeResponse }) {
  return (
    <section className="card">
      <header>
        <h2>{episode.name}</h2>
        <span>{episode.episodeCode}</span>
      </header>

      <p>
        <strong>Air date:</strong> {episode.airDate}
      </p>

      <ul className="characters">
        {episode.characters.map((c) => (
          <CharacterItem key={c.id} character={c} />
        ))}
      </ul>
    </section>
  );
}