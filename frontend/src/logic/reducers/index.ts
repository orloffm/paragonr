import { combineReducers } from "redux";
import { History } from "history";
import { connectRouter } from "connected-react-router";
import { GlobalState } from "../state/GlobalState";
import { loginReducer } from "./loginReducer";
import { authReducer } from "./authReducer";

const createRootReducer = (history: History) =>
  combineReducers<GlobalState, any>({
    auth: authReducer,
    login: loginReducer,
    router: connectRouter(history)
  });

export { createRootReducer };
