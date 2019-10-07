//import { getType } from "typesafe-actions";
//import { increment, decrement, reset } from "../actions/count/types";
import { AllLoginActions } from "../actions/login";
import { LoginState } from "../store/LoginState";

const initialState: LoginState = {
  isLoggedIn: false,
  isSubmitInProgress: false
};

function loginReducer(
  state = initialState,
  action: AllLoginActions
): LoginState {
  switch (action.type) {
    default:
      return state;
  }
}

export { loginReducer };
