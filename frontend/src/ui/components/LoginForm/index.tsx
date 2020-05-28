import { connect } from "react-redux";
import Redux, { Action } from "redux";
import { GlobalState } from "../../../logic/state/GlobalState";
import { submitLoginAsync } from "../../../logic/actions/Login/types";
import { SubmitLoginPayload } from "../../../logic/actions/Login/SubmitLoginPayload";
import { LoginFormValues, LoginFormProps, LoginForm } from "./plain";

export interface LoginFormWrapperProps { }

interface StoreProps {
  isSubmitInProgress?: boolean;
}

interface DispatchProps {
  performLogin: (values: LoginFormValues) => void;
}

function mapStateToProps(state: GlobalState): StoreProps {
  return { isSubmitInProgress: state.login.isSubmitInProgress };
}

// This creates a function that uses the dispatcher to send a message.
function mapDispatchToProps(dispatch: Redux.Dispatch<Action>): DispatchProps {
  return {
    performLogin: (values: LoginFormValues) => {
      const payload: SubmitLoginPayload = {
        userQuery: values.username,
        password: values.password
      };
      dispatch(submitLoginAsync.request(payload));
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
  GlobalState
>(
  mapStateToProps,
  mapDispatchToProps,
  mergeProps
)(LoginForm);
