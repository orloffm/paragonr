import React from "react";
import "./App.css";
// import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
// import { faCoffee } from "@fortawesome/free-solid-svg-icons";
import Currencies from "./components/Currencies";
import currenciesData from "./data/currencies-list";

// import Button from "react-bootstrap/Button";
import Navbar from "react-bootstrap/Navbar";

const App: React.FC = () => {
  return (
    <main className="container">
      <Navbar />
      <Currencies data={currenciesData.currencies} />
    </main>
  );
};

export default App;
