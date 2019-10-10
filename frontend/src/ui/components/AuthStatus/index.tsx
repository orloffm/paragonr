import Redux, { Action } from "redux";
import { connect } from "react-redux";

import { State } from "../../../logic/state/State";
import { authClear } from "../../../logic/actions/Auth/types";
import { AuthStatusProps, AuthStatus } from "./plain";

export interface AuthStatusWrapperProps {}

interface StoreProps {
  isLoggedIn: boolean;
  username?: string;
}

interface DispatchProps {
  logOut: () => void;
}

function mapStateToProps(state: State): StoreProps {
  const { isLoggedIn, username } = state.auth;

  return { isLoggedIn, username };
}

function mapDispatchToProps(dispatch: Redux.Dispatch<Action>): DispatchProps {
  return {
    logOut: () => {
      dispatch(authClear());
    }
  };
}

function mergeProps(
  stateProps: StoreProps,
  dispatchProps: DispatchProps,
  ownProps: AuthStatusWrapperProps
): AuthStatusProps {
  return {
    ...stateProps,
    ...ownProps,
    ...dispatchProps
  };
}

export default connect<
  StoreProps,
  DispatchProps,
  AuthStatusWrapperProps,
  AuthStatusProps,
  State
>(
  mapStateToProps,
  mapDispatchToProps,
  mergeProps
)(AuthStatus);
