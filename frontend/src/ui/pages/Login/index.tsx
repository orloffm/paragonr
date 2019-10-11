import * as React from "react";
import LoginForm from "../../components/LoginForm";
import { Fragment } from "react";

export interface LoginPageProps {}

export interface LoginPageState {}

export class LoginPage extends React.Component<LoginPageProps, LoginPageState> {
  render() {
    return (
      <Fragment>
        <h1>Log in</h1>
        <LoginForm />
      </Fragment>
    );
  }
}
