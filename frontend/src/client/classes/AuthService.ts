import { LoginCommandDto } from "../dtos/commands/LoginCommandDto";
import { LoginCommandResultDto } from "../dtos/commands/LoginCommandResultDto";
import { ConfigValue } from "../../data/Consts";
import { handleResponse } from "../tools/handleReponse";

export class AuthService {
  performLogin(input: LoginCommandDto): Promise<LoginCommandResultDto> {
    const requestOptions: RequestInit = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ input })
    };

    return fetch(`${ConfigValue.baseApiUrl}/auth/login`, requestOptions)
      .then(response => handleResponse<LoginCommandResultDto>(response))
      .then(user => {
        // store user details and jwt token in local storage to keep
        // user logged in between page refreshes
        // localStorage.setItem('currentUser', JSON.stringify(user));
        // currentUserSubject.next(user);

        return user;
      });
  }
}
