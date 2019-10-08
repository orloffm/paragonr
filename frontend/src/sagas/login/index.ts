import { put, delay, takeEvery, call } from "redux-saga/effects";
import {
  submitLoginAsync,
  SUBMIT_LOGIN_REQUEST
} from "../../actions/login/types";
import { SubmitLoginPayload } from "../../actions/login/SubmitLoginPayload";
import { LoginCommandResultDto } from "../../client/dtos/commands/LoginCommandResultDto";
import { AuthService } from "../../client/classes/AuthService";
import { LoginCommandDto } from "../../client/dtos/commands/LoginCommandDto";
import { SubmitLoginResponse } from "../../actions/login/SubmitLoginResponse";

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
