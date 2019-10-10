import * as React from "react";
import LoginForm from "../../components/LoginForm";

export interface LoginPageProps {}

export interface LoginPageState {}

export class LoginPage extends React.Component<LoginPageProps, LoginPageState> {
  render() {
    return <LoginForm />;
  }
}
