import { ConfigValue } from "../../data/Consts";
import { handleResponse } from "./handleReponse";

export function fetchBackendApi<TInput, TOutput>(
  path: string,
  input: TInput
): Promise<TOutput> {
  const requestOptions: RequestInit = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ input })
  };

  if (!path.startsWith("/")) {
    path = "/" + path;
  }

  const fullUrl = `${ConfigValue.baseApiUrl}${path}`;

  return fetch(fullUrl, requestOptions).then(response => handleResponse<TOutput>(response));
}
