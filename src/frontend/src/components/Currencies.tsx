import * as React from "react";
import { Component } from "react";

export interface CurrenciesData {
  id: number;
  isoCode: string;
  name: string;
}

export interface CurrenciesProps {
  data: CurrenciesData[];
}

export interface CurrenciesState {}

class Currencies extends React.Component<CurrenciesProps, CurrenciesState> {
  render() {
    return (
      <ul>
        {this.props.data.map(m => (
          <li key={m.id}>{m.isoCode}</li>
        ))}
      </ul>
    );
  }
}

export default Currencies;
