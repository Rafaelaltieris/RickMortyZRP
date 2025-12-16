import type { EpisodeResponse } from "../types/api";

const BASE_URL = import.meta.env.VITE_API_BASE_URL;

export async function getEpisode(
  id: number,
  signal?: AbortSignal
): Promise<EpisodeResponse> {
  const response = await fetch(`${BASE_URL}/api/episodes/${id}`, {
    headers: { Accept: "application/json" },
    signal,
  });

  if (response.status === 404) {
    throw new Error("Episódio não encontrado");
  }

  if (!response.ok) {
    throw new Error("Erro ao buscar episódio");
  }

  return response.json();
}