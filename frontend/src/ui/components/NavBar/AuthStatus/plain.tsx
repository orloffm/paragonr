import React, { Fragment, ReactNode } from "react";
import NavDropdown from "react-bootstrap/NavDropdown";

export interface AuthStatusPlainProps {
  isLoggedIn: boolean;
  username?: string;
  logOut: () => void;
}

export class AuthStatusPlain extends React.Component<AuthStatusPlainProps> {
  render() {
    if (!this.props.isLoggedIn) return null;

    const title: ReactNode = (
      <span>
        Hello, <b>{this.props.username}</b>!
      </span>
    );

    return (
      <NavDropdown title={title} id="basic-nav-dropdown" className="dropdown-menu-right">
        <NavDropdown.Item>
          <button
            className="btn btn-outline-success ml-3 btn-sm"
            onClick={() => this.props.logOut()}
          >
            Log Out
          </button>
        </NavDropdown.Item>
      </NavDropdown>
    );
  }
}
