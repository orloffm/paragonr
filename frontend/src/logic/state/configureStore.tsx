import { createBrowserHistory } from "history";
import { applyMiddleware, compose, createStore, DeepPartial, Middleware } from "redux";
import { routerMiddleware } from "connected-react-router";
import { createRootReducer } from "../reducers";
import { GlobalState } from "./GlobalState";

export const history = createBrowserHistory();

export default function configureStore(
  sagaMiddleware: Middleware,
  preloadedState?: DeepPartial<GlobalState>
) {
  const composeEnhancer: typeof compose =
    (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

  const store = createStore(
    createRootReducer(history),
    preloadedState,
    composeEnhancer(applyMiddleware(routerMiddleware(history), sagaMiddleware))
  );

  return store;
}
