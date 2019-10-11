import { connect } from "react-redux";

import { State } from "../../../logic/state/State";
import { RouteProps } from "react-router-dom";
import { NavBarPlain, NavBarPlainProps } from "./plain";
import { RouteData } from "../../routes/RoutesData";

export interface NavBarWrapperProps extends RouteProps {
  routes: RouteData[];
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
  ownProps: NavBarWrapperProps
): NavBarPlainProps {
  return {
    ...stateProps,
    ...ownProps
  };
}

export default connect<StoreProps, {}, NavBarWrapperProps, NavBarPlainProps, State>(
  mapStateToProps,
  undefined,
  mergeProps
)(NavBarPlain);
