import { connect } from "react-redux";

import { State } from "../../../logic/state/State";
import { RouteProps } from "react-router-dom";
import { PrivateRoutePlain, PrivateRoutePlainProps } from "./plain";

export interface PrivateRouteWrapperProps extends RouteProps {
  loginPath: string;
}

interface StoreProps {
  isLoggedIn: boolean;
}

function mapStateToProps(state: State): StoreProps {
  return { isLoggedIn: state.auth.isLoggedIn };
}

function mergeProps(
  stateProps: StoreProps,
  _: undefined,
  ownProps: PrivateRouteWrapperProps
): PrivateRoutePlainProps {
  return {
    ...stateProps,
    ...ownProps
  };
}

export default connect<
  StoreProps,
  {},
  PrivateRouteWrapperProps,
  PrivateRoutePlainProps,
  State
>(
  mapStateToProps,
  undefined,
  mergeProps
)(PrivateRoutePlain);
