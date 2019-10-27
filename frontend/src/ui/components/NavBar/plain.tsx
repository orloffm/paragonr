import * as React from "react";
import { NavLink } from "react-router-dom";
import { RouteData } from "../../routes/RoutesData";
import { getPath } from "../../routes/getPath";
import AuthStatus from "./AuthStatus";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";

export interface NavBarPlainProps {
  isLoggedIn: boolean;
  routes: RouteData[];
}

export class NavBarPlain extends React.Component<NavBarPlainProps> {
  render() {
    return (
      <Navbar bg="dark" expand="lg" variant="dark" className="justify-content-between">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <NavLink to="/" className="navbar-brand" exact>
              Paragonr
            </NavLink>
            {this.props.routes.map(item => this.renderNavItem(item))}
          </Nav>
          <Nav>
            <AuthStatus />
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }

  private renderNavItem(item: RouteData): JSX.Element | null {
    if (this.props.isLoggedIn) {
      if (item.onlyAnonymous === true) {
        return null;
      }
    } else {
      if (!(item.allowAnonymous === true)) {
        return null;
      }
    }

    return (
      <NavLink to={getPath(item.key)} key={item.key} className="nav-link">
        {item.title}
      </NavLink>
    );
  }
}
