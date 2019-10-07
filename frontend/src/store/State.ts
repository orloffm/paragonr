import { RouterState } from "connected-react-router";
import { LoginState } from "./LoginState";

export interface State {
  login: LoginState;
  router: RouterState;
}
