import React from "react";
import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import routes from "./routes";

import { NavBar, NavBarItem } from "./components/Bootstrap/NavBar";

interface AppProps {
  history: History;
}

const navBarItems: NavBarItem[] = [
  { url: "spendings", title: "Spendings" },
  { url: "currencies", title: "Currencies" },
  { url: "categories", title: "Categories" }
];

const App: React.FC<AppProps> = props => (
  <ConnectedRouter history={props.history}>
    <div>
      <NavBar items={navBarItems} />
      <main className="container">{routes}</main>
    </div>
  </ConnectedRouter>
);

export default App;
