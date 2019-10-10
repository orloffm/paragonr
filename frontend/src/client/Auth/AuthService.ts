import { LoginCommandDto } from "./LoginCommandDto";
import { LoginCommandResultDto } from "./LoginCommandResultDto";
import { fetchBackendApi } from "../common/fetchBackendApi";

export class AuthService {
  performLogin(input: LoginCommandDto): Promise<LoginCommandResultDto> {
    return fetchBackendApi<LoginCommandDto, LoginCommandResultDto>("auth/login", input);
  }
}
