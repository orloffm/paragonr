import { getType } from "typesafe-actions";

import { AllLoginActions } from "../actions/login";
import { LoginState } from "../store/LoginState";
import { submitLoginAsync } from "../actions/login/types";

const initialState: LoginState = {
  isLoggedIn: false,
  isSubmitInProgress: false,
};

function loginReducer(state = initialState, action: AllLoginActions): LoginState {
  switch (action.type) {
    case getType(submitLoginAsync.request):
      console.debug("Processing submitLoginAsync.request.");
      return {
        ...state,
        isLoggedIn: false,
        isSubmitInProgress: true,
      };

    case getType(submitLoginAsync.success):
      console.debug("Processing submitLoginAsync.success.");
      return {
        ...state,
        isLoggedIn: true,
        isSubmitInProgress: false,
      };

    case getType(submitLoginAsync.failure):
      console.debug("Processing submitLoginAsync.failure.");
      return {
        ...state,
        isLoggedIn: false,
        isSubmitInProgress: false,
      };

    default:
      return state;
  }
}

export { loginReducer };
