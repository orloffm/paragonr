import React from "react";

export interface AuthStatusProps {
  isLoggedIn: boolean;
  username?: string;
  logOut: () => void;
}

export class AuthStatus extends React.Component<AuthStatusProps> {
  render() {
    if (this.props.isLoggedIn) {
      return (
        <div>
          Hello, <b>{this.props.username}</b>!
          <button onClick={() => this.props.logOut()}>Log Out</button>
        </div>
      );
    } else {
      return <div>Not logged in.</div>;
    }
  }
}
