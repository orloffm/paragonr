import { put, takeEvery, all, call } from "redux-saga/effects";

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

export function* rootSaga() {
  yield all([
    helloSaga()
    //  , watchIncrementAsync()
  ]);
}
