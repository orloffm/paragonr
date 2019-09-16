import { combineReducers } from "redux";
import { History } from "history";
import { connectRouter } from "connected-react-router";

//import { countReducer } from "./count";

const rootReducer = (history: History) =>
  combineReducers({
    // count: countReducer,
    router: connectRouter(history)
  });

export default rootReducer;
