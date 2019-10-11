import React from "react";
import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import { renderRouteDatas } from "./ui/routes";

import NavBar from "./ui/components/Bootstrap/NavBar/";
import { AppRoutes } from "./ui/routes/RoutesData";

interface AppProps {
  history: History;
}

const routes = renderRouteDatas();

const App: React.FC<AppProps> = props => (
  <ConnectedRouter history={props.history}>
    <div>
      <NavBar routes={AppRoutes.routes} />
      <main className="container">{routes}</main>
    </div>
  </ConnectedRouter>
);

export default App;
