import React from "react";
import Currencies from "./components/currencies/main";
import infoGeneric from "./data/info-generic";
import { Route, Redirect, Link, NavLink, Switch } from "react-router-dom";
import Categories from "./components/categories";
import Spendings from "./components/spendings";
import NotFound from "./components/notFound";
import Home from "./components/home";

const App: React.FC = () => {
  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <a className="navbar-brand" href="#">
          Paragonr
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon" />
        </button>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item">
              <NavLink to="/" className="nav-link" exact>
                Home
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink to="/currencies" className="nav-link">
                Currencies
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink to="/categories" className="nav-link">
                Categories
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink to="/spendings" className="nav-link">
                Spendings
              </NavLink>
            </li>
          </ul>
        </div>
      </nav>

      <main className="container">
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
          <Route path="/categories" component={Categories} />
          <Route path="/spendings" component={Spendings} />
          <Route path="/not-found" component={NotFound} />
          <Route path="/" exact component={Home} />
          <Redirect to="/not-found" />
        </Switch>
      </main>
    </div>
  );
};

export default App;
