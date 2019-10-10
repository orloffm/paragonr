import { getType } from "typesafe-actions";

import { AllAuthActions } from "../actions/Auth";
import { AuthState } from "../state/slices/AuthState";
import { authSet, authClear } from "../actions/Auth/types";

const initialState: AuthState = {
  isLoggedIn: false,
  token: undefined
};

function authReducer(state = initialState, action: AllAuthActions): AuthState {
  switch (action.type) {
    case getType(authSet):
      console.debug("Processing authSet.");
      return {
        ...state
      };

    case getType(authClear):
      console.debug("Processing authClear.");
      return {
        ...state
      };

    default:
      return state;
  }
}

export { authReducer };
