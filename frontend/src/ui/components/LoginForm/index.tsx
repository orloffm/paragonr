import { Formik, Form, FormikProps, Field, FormikActions } from "formik";
import React from "react";
import { connect } from "react-redux";
import { submitLoginAsync } from "../../actions/login/types";
import Redux, { Action } from "redux";
import { State } from "../../store/State";

// PLAIN =====================================================================

export interface LoginFormValues {
  username: string;
  password: string;
}

const initialValues: LoginFormValues = {
  username: "",
  password: ""
};

export interface LoginFormProps {
  isSubmitInProgress?: boolean;
  performLogin: (values: LoginFormValues) => void;
}

class LoginForm extends React.Component<LoginFormProps> {
  render() {
    return (
      <Formik
        initialValues={initialValues}
        onSubmit={(
          values: LoginFormValues,
          _: FormikActions<LoginFormValues>
        ) => this.props.performLogin(values)}
        render={(formikBag: FormikProps<LoginFormValues>) => {
          const { touched, errors } = formikBag;

          return (
            <Form>
              <Field type="username" name="username" />
              {touched.username && errors.username && (
                <div>{errors.username}</div>
              )}

              <Field type="password" name="password" />
              {touched.password && errors.password && (
                <div>{errors.password}</div>
              )}

              {this.props.isSubmitInProgress && <div>running</div>}

              {!this.props.isSubmitInProgress && (
                <button type="submit" disabled={this.props.isSubmitInProgress}>
                  Submit
                </button>
              )}
            </Form>
          );
        }}
      />
    );
  }
}

// WRAP ================================================================

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
    performLogin: (values: LoginFormValues) =>
      dispatch(submitLoginAsync.request(values))
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
