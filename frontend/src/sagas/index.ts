import {
  put,
  takeEvery,
  all
  // , call
} from "redux-saga/effects";
import { submitLoginAsync, SUBMIT_LOGIN_REQUEST } from "../actions/login/types";

function* helloSaga() {
  console.log("Hello Sagas!");
}

// function* incrementAsync() {
//   try {
//     yield call(delay, 1000);
//     yield put({ type: "INCREMENT" });
//   } catch (e) {
//     console.log(e);
//   }
// }

// function* watchIncrementAsync() {
//   yield takeEvery("INCREMENT_ASYNC", incrementAsync);
// }

function* submitLoginRequestSaga(
  action: ReturnType<typeof submitLoginAsync.request>
): Generator {
  console.log("SUBMIT_LOGIN_REQUEST runs.");

  try {
    // const response: Todo[] = yield call(todosApi.getAll, action.payload);

    yield put(submitLoginAsync.success());
  } catch (err) {
    yield put(submitLoginAsync.failure(err));
  }
}

export function* rootSaga() {
  yield all([
    helloSaga()
    //  , watchIncrementAsync()
  ]);

  yield takeEvery(SUBMIT_LOGIN_REQUEST, submitLoginRequestSaga);
}
