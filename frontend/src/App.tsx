import React from "react";
import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import { getRouteDatas } from "./ui/routes";

import { NavBar, NavBarItem } from "./ui/components/Bootstrap/NavBar";

interface AppProps {
  history: History;
}

const navBarItems: NavBarItem[] = [
  { url: "login", title: "Login" },
  { url: "spendings", title: "Spendings" },
  { url: "currencies", title: "Currencies" },
  { url: "categories", title: "Categories" }
];

const routes = getRouteDatas();

const App: React.FC<AppProps> = props => (
  <ConnectedRouter history={props.history}>
    <div>
      <NavBar items={navBarItems} />
      <main className="container">{routes}</main>
    </div>
  </ConnectedRouter>
);

export default App;
