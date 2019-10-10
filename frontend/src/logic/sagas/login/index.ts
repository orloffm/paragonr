import { put, delay, takeEvery, call } from "redux-saga/effects";
import { AuthService } from "../../../client/Auth/AuthService";
import { LoginCommandDto } from "../../../client/Auth/LoginCommandDto";
import { SubmitLoginResponse } from "../../actions/login/SubmitLoginResponse";
import { submitLoginAsync, SUBMIT_LOGIN_REQUEST } from "../../actions/login/types";
import { AuthSetPayload } from "../../actions/Auth/AuthSetPayload";
import { LoginCommandResultDto } from "../../../client/Auth/LoginCommandResultDto";
import { authSet, authClear } from "../../actions/Auth/types";

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
    const output = yield call(authService.performLogin, input);
    const responseDto = output as LoginCommandResultDto;

    const response: AuthSetPayload = {
      firstName: responseDto.firstName,
      lastName: responseDto.lastName,
      token: responseDto.token,
      email: responseDto.email,
      username: responseDto.username,
      isAdmin: responseDto.isAdmin
    };

    console.debug("submitLoginRequestSaga runs: putting authSet.");
    yield put(authSet(response));

    console.debug("submitLoginRequestSaga runs: putting submitLoginAsync.success.");
    yield put(submitLoginAsync.success());
  } catch (err) {
    console.debug("submitLoginRequestSaga runs: putting authClear.");
    yield put(authClear());

    console.debug("submitLoginRequestSaga runs: putting submitLoginAsync.failure. " + err);
    yield put(submitLoginAsync.failure(err));
  }
}

export function* rootLoginSaga() {
  yield takeEvery(SUBMIT_LOGIN_REQUEST, submitLoginRequestSaga);
}
