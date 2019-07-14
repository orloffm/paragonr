import * as React from "react";
import { CurrenciesData } from "./currenciesData";
import CurrenciesTable from "./currenciesTable";

export interface CurrenciesProps {
  data: CurrenciesData[];
}

export interface CurrenciesState {}

class Currencies extends React.Component<CurrenciesProps, CurrenciesState> {
  render() {
    return <CurrenciesTable data={this.props.data} />;
  }
}

export default Currencies;
