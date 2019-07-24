import React from "react";
import Currencies from "./components/currencies";
import currenciesData from "./data/info-generic";

import Navbar from "react-bootstrap/Navbar";

const App: React.FC = () => {
  return (
    <main className="container">
      <Navbar bg="dark" variant="dark">
        <Navbar.Brand href="#home">Paragonr</Navbar.Brand>
      </Navbar>
      <Currencies data={currenciesData.currencies} />
    </main>
  );
};

export default App;
