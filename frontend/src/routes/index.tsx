import React from "react";
import { Route, Switch, Redirect } from "react-router";

import Home from "../pages/Home";
import { Currencies } from "../pages/Currencies";
import { Categories } from "../pages/Categories";
import { Spendings } from "../pages/Spendings";
import { NotFound } from "../pages/NotFound";
import { LoginPage } from "../pages/Login";
import { PrivateRoute } from "../components/PrivateRoute";

const routes = (
  <Switch>
    <Route path="/login" component={LoginPage} />
    <Route path="/currencies" component={Currencies} />
    <Route path="/categories" component={Categories} />
    <PrivateRoute path="/spendings" component={Spendings} isLoggedIn={false} />
    <Route path="/not-found" component={NotFound} />
    <Route path="/" exact component={Home} />
    <Redirect to="/not-found" />
  </Switch>
);

export default routes;
