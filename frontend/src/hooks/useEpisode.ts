import { useEffect, useRef, useState } from "react";
import { getEpisode } from "../services/api";
import type { EpisodeResponse } from "../types/api";

type State = {
  data: EpisodeResponse | null;
  loading: boolean;
  error: string | null;
};

export function useEpisode(episodeId: number | null) {
  const [state, setState] = useState<State>({
    data: null,
    loading: false,
    error: null,
  });

  const abortRef = useRef<AbortController | null>(null);

  useEffect(() => {
    if (episodeId == null) return;

    abortRef.current?.abort();
    const controller = new AbortController();
    abortRef.current = controller;

    setState({ data: null, loading: true, error: null });

    getEpisode(episodeId, controller.signal)
      .then((data) =>
        setState({ data, loading: false, error: null })
      )
      .catch((err) => {
        if (controller.signal.aborted) return;
        setState({
          data: null,
          loading: false,
          error: err instanceof Error ? err.message : "Erro desconhecido",
        });
      });

    return () => controller.abort();
  }, [episodeId]);

  return state;
}