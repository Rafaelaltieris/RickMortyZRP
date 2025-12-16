import { useState } from "react";
import { useEpisode } from "./hooks/useEpisode";
import { EpisodeCard } from "./components/EpisodeCard";

export default function App() {
  const [episodeId, setEpisodeId] = useState<number | null>(1);
  const [input, setInput] = useState("1");

  const { data, loading, error } = useEpisode(episodeId);

  function search() {
    const id = Number(input);
    if (id > 0) setEpisodeId(id);
  }

  return (
    <main className="container">
      <h1>Rick & Morty Episodes</h1>

      <div className="search">
        <input
          value={input}
          onChange={(e) => setInput(e.target.value)}
          placeholder="Episode ID"
        />
        <button onClick={search}>Buscar</button>
      </div>

      {loading && <p>Carregando...</p>}
      {error && <p className="error">{error}</p>}
      {data && <EpisodeCard episode={data} />}
    </main>
  );
}