import * as React from "react";
import AuthStatus from "../../components/AuthStatus";

export interface HomeProps {}

export interface HomeState {}

class Home extends React.Component<HomeProps, HomeState> {
  render() {
    return (
      <div>
        <h1>Home</h1>
        <AuthStatus />
      </div>
    );
  }
}

export default Home;
