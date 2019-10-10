import { put, delay, takeEvery, call } from "redux-saga/effects";
import { AuthService } from "../../../client/Auth/AuthService";
import { LoginCommandDto } from "../../../client/Auth/LoginCommandDto";
import { SubmitLoginResponse } from "../../actions/login/SubmitLoginResponse";
import { submitLoginAsync, SUBMIT_LOGIN_REQUEST } from "../../actions/login/types";

function* submitLoginRequestSaga(
  action: ReturnType<typeof submitLoginAsync.request>
): Generator {
  console.debug("submitLoginRequestSaga runs.");

  try {
    yield delay(500);

    const authService = new AuthService();
    const input: LoginCommandDto = {
      userName: action.payload.username,
      password: action.payload.password
    };

    const responseDto = yield call(authService.performLogin, input);
    const response: SubmitLoginResponse = responseDto as SubmitLoginResponse;

    console.debug("submitLoginRequestSaga runs: putting success.");
    yield put(submitLoginAsync.success(response));
  } catch (err) {
    console.debug("submitLoginRequestSaga runs: putting failure. " + err);
    yield put(submitLoginAsync.failure(err));
  }
}

export function* rootLoginSaga() {
  yield takeEvery(SUBMIT_LOGIN_REQUEST, submitLoginRequestSaga);
}
