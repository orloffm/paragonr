import { ErrorResultDto } from "../dtos/commands/ErrorResultDto";

export function handleResponse<T>(response: Response): Promise<T> {
  return response.text().then(text => {
    const data: any = text && JSON.parse(text);
    if (!response.ok) {
      if ([401, 403].indexOf(response.status) !== -1) {
        // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
        // authenticationService.logout();
        // location.reload(true);
      }

      const errorData = data as ErrorResultDto;
      const error = (errorData && errorData.message) || response.statusText;
      return Promise.reject(error);
    }

    const typedData = data as T;
    if (typedData === undefined) {
      return Promise.reject("Empty response returned.");
    }
    return typedData;
  });
}
