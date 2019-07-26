import React from "react";
import Currencies from "./components/currencies/main";
import infoGeneric from "./data/info-generic";
import { Route, Redirect, Link, Switch } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Categories from "./components/categories";
import Spendings from "./components/spendings";
import NotFound from "./components/notFound";
import Home from "./components/home";

const App: React.FC = () => {
  return (
    <main className="container">
      <Navbar bg="dark" variant="dark">
        <Navbar.Brand href="#home">Paragonr</Navbar.Brand>
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Link to="/">Home</Link>
            <Link to="/currencies">Currencies</Link>
            <Link to="/categories">Categories</Link>
            <Link to="/spendings">Spendings</Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
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
  );
};

export default App;
