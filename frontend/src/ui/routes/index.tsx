import React from "react";
import { Route, Switch, Redirect } from "react-router";

import { RouteData, AppRoutes } from "./RoutesData";
import PrivateRoute from "../components/PrivateRoute";

function renderRouteData(r: RouteData, loginKey: string): JSX.Element {
  const path = getPath(r.key);

  if (r.public) {
    return <Route path={path} key={r.key} component={r.component} />;
  } else {
    return (
      <PrivateRoute
        path={path}
        key={r.key}
        component={r.component}
        loginPath={getPath(loginKey)}
      />
    );
  }
}

function getPath(key: string): string {
  return "/" + key;
}

export function renderRouteDatas() {
  const rr = AppRoutes;

  return (
    <Switch>
      {rr.routes.map(r => renderRouteData(r, AppRoutes.loginKey))};
      <Route path={getPath(rr.notFoundKey)} component={rr.notFoundComponent} />
      <Route path={getPath(rr.homeKey)} exact component={rr.homeComponent} />
      <Redirect to={getPath(rr.notFoundKey)} />
    </Switch>
  );
}
