import { Formik, Form, FormikProps, Field, FormikActions } from "formik";
import React from "react";

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
            <Form>
              <Field type="username" name="username" />
              {touched.username && errors.username && <div>{errors.username}</div>}

              <Field type="password" name="password" />
              {touched.password && errors.password && <div>{errors.password}</div>}

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
