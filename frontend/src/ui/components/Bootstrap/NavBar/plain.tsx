import * as React from "react";
import { NavLink } from "react-router-dom";
import { RouteData } from "../../../routes/RoutesData";
import { getPath } from "../../../routes/getPath";

export interface NavBarPlainProps {
  isLoggedIn: boolean;
  routes: RouteData[];
}

export class NavBarPlain extends React.Component<NavBarPlainProps> {
  render() {
    return (
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <NavLink to="/" className="navbar-brand" exact>
          Paragonr
        </NavLink>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            {this.props.routes.map(item => this.renderNavItem(item))}
          </ul>
        </div>
      </nav>
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
      <li className="nav-item" key={item.key}>
        <NavLink to={getPath(item.key)} className="nav-link">
          {item.title}
        </NavLink>
      </li>
    );
  }
}
