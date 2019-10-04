import * as React from "react";
import { NavLink } from "react-router-dom";

export interface NavBarProps {
  items: NavBarItem[];
}

export interface NavBarItem {
  url: string;
  title: string;
}

export class NavBar extends React.Component<NavBarProps> {
  render() {
    return (
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <NavLink to="/" className="navbar-brand" exact>
          Paragonr
        </NavLink>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            {this.props.items.map(item => (
              <li className="nav-item">
                <NavLink
                  to={"/" + item.url}
                  key={item.title}
                  className="nav-link"
                >
                  {item.title}
                </NavLink>
              </li>
            ))}
          </ul>
        </div>
      </nav>
    );
  }
}
