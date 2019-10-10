import { getType } from "typesafe-actions";

import { AllAuthActions } from "../actions/Auth";
import { AuthState } from "../state/slices/AuthState";
import { authSet, authClear } from "../actions/Auth/types";
import { AuthSetPayload } from "../actions/Auth/AuthSetPayload";

const initialState: AuthState = {
  isLoggedIn: false,
  token: undefined
};

function authReducer(state = initialState, action: AllAuthActions): AuthState {
  switch (action.type) {
    case getType(authSet):
      console.debug("Processing authSet.");
      const authSetPayload = action.payload as AuthSetPayload;
      return {
        ...state,
        firstName: authSetPayload.firstName,
        lastName: authSetPayload.lastName,
        username: authSetPayload.username,
        email: authSetPayload.email,
        isAdmin: authSetPayload.isAdmin,
        isLoggedIn: true,
        token: authSetPayload.token
      };

    case getType(authClear):
      console.debug("Processing authClear.");
      return initialState;

    default:
      return state;
  }
}

export { authReducer };
