import React from "react";
import { Route, Switch, Redirect } from "react-router";

import infoGeneric from "../data/info-generic";
import Home from "../pages/Home";
import { Currencies } from "../pages/Currencies";
import { Categories } from "../pages/Categories";
import { Spendings } from "../pages/Spendings";
import { NotFound } from "../pages/NotFound";
import { Login } from "../pages/Login";

const routes = (
  <Switch>
    <Route path="/login" component={Login} />
    <Route path="/currencies" component={Currencies} />
    <Route path="/categories" component={Categories} />
    <Route path="/spendings" component={Spendings} />
    <Route path="/not-found" component={NotFound} />
    <Route path="/" exact component={Home} />
    <Redirect to="/not-found" />
  </Switch>
);

export default routes;
