import { combineReducers } from "redux";
import { History } from "history";
import { connectRouter } from "connected-react-router";
import { State } from "../state/State";
import { loginReducer } from "./loginReducer";

const createRootReducer = (history: History) =>
  combineReducers<State, any>({
    login: loginReducer,
    router: connectRouter(history),
  });

export { createRootReducer };
