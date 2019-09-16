import React from "react";
import { Route, Switch, Redirect } from "react-router";

import infoGeneric from "../data/info-generic";
import Home from "../pages/Home";
import { Currencies } from "../components/Currencies";
import { Categories } from "../components/Categories";
import { Spendings } from "../pages/Spendings";
import { NotFound } from "../pages/NotFound";

const routes = (
  <Switch>
    <Route
      path="/currencies"
      render={() => (
        <Currencies
          currencies={infoGeneric.currencies}
          ratesInfo={infoGeneric.ratesInfo}
        />
      )}
    />
    <Route
      path="/categories"
      render={() => (
        <Categories
          domains={infoGeneric.domains}
          categories={infoGeneric.categories}
        />
      )}
    />
    <Route path="/spendings" component={Spendings} />
    <Route path="/not-found" component={NotFound} />
    <Route path="/" exact component={Home} />
    <Redirect to="/not-found" />
  </Switch>
);

export default routes;
