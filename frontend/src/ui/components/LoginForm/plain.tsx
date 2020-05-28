import { Formik, Form, FormikProps, Field, FormikActions } from "formik";
import React, { Fragment } from "react";
import ErrorAlert from "../Bootstrap/ErrorAlert";

export interface LoginFormValues {
  username: string;
  password: string;
}

const initialValues: LoginFormValues = {
  username: "",
  password: ""
};

// Bare properties that are not aware of the outer world.
export interface LoginFormProps {
  isSubmitInProgress?: boolean;
  errorMessage?: string | null;
  performLogin: (values: LoginFormValues) => void;
}

export class LoginForm extends React.Component<LoginFormProps> {
  render() {
    return (
      <Formik
        initialValues={initialValues}
        onSubmit={(values: LoginFormValues, _: FormikActions<LoginFormValues>) =>
          this.props.performLogin(values)
        }
        render={(formikBag: FormikProps<LoginFormValues>) => {
          const { touched, errors } = formikBag;

          return (
            <Fragment>
              <Form>
                <Field type="username" name="username" />
                {touched.username && errors.username && (
                  <ErrorAlert>{errors.password}</ErrorAlert>
                )}

                <Field type="password" name="password" />
                {touched.password && errors.password && (
                  <ErrorAlert>{errors.password}</ErrorAlert>
                )}

                {this.props.isSubmitInProgress && <div>running</div>}

                {!this.props.isSubmitInProgress && (
                  <button type="submit" disabled={this.props.isSubmitInProgress}>
                    Submit
                  </button>
                )}
              </Form>
              {this.props.errorMessage && <ErrorAlert>{errors.password}</ErrorAlert>}
            </Fragment>
          );
        }}
      />
    );
  }
}
