import type { Character } from "../types/api";

export function CharacterItem({ character }: { character: Character }) {
  return (
    <li className="character">
      <img src={character.image} alt={character.name} />
      <div>
        <strong>{character.name}</strong>
        <span>
          {character.status} • {character.species}
        </span>
      </div>
    </li>
  );
}