import { RouterState } from "connected-react-router";
import { LoginState } from "./slices/LoginState";
import { AuthState } from "./slices/AuthState";

export interface GlobalState {
  auth: AuthState;
  login: LoginState;
  router: RouterState;
}
