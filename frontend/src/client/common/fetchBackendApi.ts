import { getConfig } from "../../data/Config";
import { handleResponse } from "./handleReponse";

export function fetchBackendApi<TInput, TOutput>(
  path: string,
  input: TInput
): Promise<TOutput> {
  const requestOptions: RequestInit = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(input),
  };

  if (!path.startsWith("/")) {
    path = "/" + path;
  }

  const configValue = getConfig();
  const fullUrl = `${configValue.baseApiUrl}${path}`;

  return fetch(fullUrl, requestOptions).then((response) =>
    handleResponse<TOutput>(response)
  );
}
