import { combineReducers } from "redux";
import { History } from "history";
import { connectRouter } from "connected-react-router";
import { State } from "../store/State";
import { loginReducer } from "./loginReducer";

const rootReducer = (history: History) =>
  combineReducers<State, any>({
    login: loginReducer,
    router: connectRouter(history)
  });

export default rootReducer;