import React from "react";

export interface AuthStatusPlainProps {
  isLoggedIn: boolean;
  username?: string;
  logOut: () => void;
}

export class AuthStatusPlain extends React.Component<AuthStatusPlainProps> {
  render() {
    if (!this.props.isLoggedIn) return null;

    return (
      <div className="mr-auto">
        <span className="navbar-text">
          Hello, <b>{this.props.username}</b>!
        </span>
        <button
          className="btn btn-outline-success ml-3 btn-sm"
          onClick={() => this.props.logOut()}
        >
          Log Out
        </button>
      </div>
    );
  }
}
