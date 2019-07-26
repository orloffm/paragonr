import * as React from "react";
import { CurrenciesData } from "../../dtos/CurrenciesData";
import CurrenciesTable from "./table";
import { RatesInfoData } from "../../dtos/RatesInfoData";
import { CurrenciesRow } from "./CurrenciesRow";
import { RateInfoData } from "../../dtos/RateInfoData";

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
      const defaultIsoCode = this.props.ratesInfo.defaultCurrency;
      const rates = this.props.ratesInfo.rates;

      let row: CurrenciesRow = new CurrenciesRow(currency);

      if (defaultIsoCode === currency.isoCode) {
        row.isMain = true;
      } else {
        const rateInfo: RateInfoData | undefined = rates.find(
          r => r.isoCode === currency.isoCode
        );
        if (rateInfo !== undefined) {
          row.rateToMain = rateInfo.rate;
          row.date = new Date(rateInfo.date).toLocaleDateString();
        }
      }

      rows.push(row);
    }

    return <CurrenciesTable data={rows} />;
  }
}

export default Currencies;
