import { connect } from "react-redux";

import { GlobalState } from "../../../logic/state/GlobalState";
import { RouteProps } from "react-router-dom";
import { NavBarPlain, NavBarPlainProps } from "./plain";
import { RouteData } from "../../routes/RoutesData";

export interface NavBarWrapperProps extends RouteProps {
  routes: RouteData[];
}

interface StoreProps {
  isLoggedIn: boolean;
}

function mapStateToProps(state: GlobalState): StoreProps {
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

export default connect<StoreProps, {}, NavBarWrapperProps, NavBarPlainProps, GlobalState>(
  mapStateToProps,
  undefined,
  mergeProps
)(NavBarPlain);
