import * as React from "react";
import { CurrenciesData } from "../../dtos/CurrenciesData";
import CurrenciesTable from "./table";
import { RatesInfoData } from "../../dtos/RatesInfoData";
import { CurrenciesRow } from "./CurrenciesRow";

export interface CurrenciesProps {
  currencies: CurrenciesData[];
  ratesInfo: RatesInfoData;
}

export interface CurrenciesState {}

class Currencies extends React.Component<CurrenciesProps, CurrenciesState> {
  render() {
    let rows: Array<CurrenciesRow> = [];

    for (let i = 0; i < this.props.currencies.length; i++) {
      const currency = this.props.currencies[i];

      let row: CurrenciesRow = new CurrenciesRow(currency);

      rows.push(row);
    }

    return <CurrenciesTable data={rows} />;
  }
}

export default Currencies;
