import React from "react";
import { Route, Switch, Redirect } from "react-router";

import { RouteData, AppRoutes } from "./RoutesData";
import { PrivateRoute } from "../components/PrivateRoute";

function renderRouteData(r: RouteData): JSX.Element {
  const path = getPath(r.key);

  if (r.public == true) {
    return <Route path={path} key={r.key} component={r.component} />;
  } else {
    return <PrivateRoute path={path} key={r.key} component={r.component} />;
  }
}

function getPath(key: string): string {
  return "/" + key;
}

export function getRoutes() {
  const rr = AppRoutes;

  return (
    <Switch>
      {rr.routes.map(renderRouteData)};
      <Route path={getPath(rr.notFoundKey)} component={rr.notFoundComponent} />
      <Route path={getPath(rr.homeKey)} exact component={rr.homeComponent} />
      <Redirect to={getPath(rr.notFoundKey)} />
    </Switch>
  );
}
