import { fork, call } from "redux-saga/effects";
import { rootLoginSaga } from "./Login";

function helloSaga() {
  console.debug("Hello Sagas!");
}

export function* rootSaga() {
  yield call(helloSaga);
  yield fork(rootLoginSaga);
}
