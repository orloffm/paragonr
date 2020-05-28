import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import createSagaMiddleware from "redux-saga";

import App from "./App";
// import * as serviceWorker from "./serviceWorker";
import configureStore, { history } from "./logic/state/configureStore";
import { rootSaga } from "./logic/sagas";
import { GlobalState } from "./logic/state/GlobalState";
import { DeepPartial } from "redux";

const sagaMiddleware = createSagaMiddleware();

//let preloadedState: DeepPartial<State> = {};

const store = configureStore(sagaMiddleware);

sagaMiddleware.run(rootSaga);

ReactDOM.render(
  <Provider store={store}>
    <App history={history} />
  </Provider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
//serviceWorker.unregister();
