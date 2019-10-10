import { connect } from "react-redux";
import Redux, { Action } from "redux";
import { State } from "../../../logic/state/State";
import { submitLoginAsync } from "../../../logic/actions/Login/types";
import { SubmitLoginPayload } from "../../../logic/actions/Login/SubmitLoginPayload";
import { LoginFormValues, LoginFormProps, LoginForm } from "./plain";

export interface LoginFormWrapperProps {}

interface StoreProps {
  isSubmitInProgress?: boolean;
}

interface DispatchProps {
  performLogin: (values: LoginFormValues) => void;
}

function mapStateToProps(state: State): StoreProps {
  return { isSubmitInProgress: state.login.isSubmitInProgress };
}

function mapDispatchToProps(dispatch: Redux.Dispatch<Action>): DispatchProps {
  return {
    performLogin: (values: LoginFormValues) => {
      const payload: SubmitLoginPayload = {
        username: values.username,
        password: values.password
      };
      dispatch(submitLoginAsync.request(values));
    }
  };
}

function mergeProps(
  stateProps: StoreProps,
  dispatchProps: DispatchProps,
  ownProps: LoginFormWrapperProps
): LoginFormProps {
  return {
    ...stateProps,
    ...ownProps,
    ...dispatchProps
  };
}

export default connect<
  StoreProps,
  DispatchProps,
  LoginFormWrapperProps,
  LoginFormProps,
  State
>(
  mapStateToProps,
  mapDispatchToProps,
  mergeProps
)(LoginForm);
