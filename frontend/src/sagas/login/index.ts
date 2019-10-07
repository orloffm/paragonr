import { put, delay, takeEvery } from "redux-saga/effects";
import {
  submitLoginAsync,
  SUBMIT_LOGIN_REQUEST
} from "../../actions/login/types";

function* submitLoginRequestSaga(
  action: ReturnType<typeof submitLoginAsync.request>
): Generator {
  console.debug("submitLoginRequestSaga runs.");

  try {
    yield delay(500);

    // const response: Todo[] = yield call(todosApi.getAll, action.payload);

    console.debug("submitLoginRequestSaga runs: putting success.");
    yield put(submitLoginAsync.success());
  } catch (err) {
    console.debug("submitLoginRequestSaga runs: putting failure. " + err);
    yield put(submitLoginAsync.failure(err));
  }
}

export function* rootLoginSaga() {
  yield takeEvery(SUBMIT_LOGIN_REQUEST, submitLoginRequestSaga);
}
