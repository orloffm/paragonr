import React from "react";
import Currencies from "./components/currencies/main";
import infoGeneric from "./data/info-generic";
import {
  Route,
  Redirect,
  Link,
  NavLink,
  Switch,
  BrowserRouter
} from "react-router-dom";
import Categories from "./components/categories/main";
import Spendings from "./components/spendings";
import NotFound from "./components/notFound";
import Home from "./components/home";
import NavBar from "./components/navBar";

const App: React.FC = () => {
  return (
    <BrowserRouter>
      <NavBar />

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
      </main>
    </BrowserRouter>
  );
};

export default App;
