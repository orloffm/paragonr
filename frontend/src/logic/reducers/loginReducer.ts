import { getType } from "typesafe-actions";

import { AllLoginActions } from "../actions/Login";
import { LoginState } from "../state/slices/LoginState";
import { submitLoginAsync } from "../actions/Login/types";

const initialState: LoginState = {
  isSubmitInProgress: false,
  errorMessage: null
};

function loginReducer(state = initialState, action: AllLoginActions): LoginState {
  switch (action.type) {
    case getType(submitLoginAsync.request):
      console.debug("Processing submitLoginAsync.request.");
      return {
        ...state,
        isSubmitInProgress: true,
        errorMessage: null
      };

    case getType(submitLoginAsync.success):
      console.debug("Processing submitLoginAsync.success.");
      return {
        ...state,
        isSubmitInProgress: false,
        errorMessage: null
      };

    case getType(submitLoginAsync.failure):
      console.debug("Processing submitLoginAsync.failure.");
      return {
        ...state,
        isSubmitInProgress: false,
        errorMessage: action.payload.message
      };

    default:
      return state;
  }
}

export { loginReducer };
