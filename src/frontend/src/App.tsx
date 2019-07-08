import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCoffee } from "@fortawesome/free-solid-svg-icons";
import Spendings from "./components/Spendings";

import Button from "react-bootstrap/Button";

const App: React.FC = () => {
  return (
    <main className="container">
      <Spendings />
    </main>
  );
};

export default App;
