import * as React from "react";
import CurrenciesTable from "./table";
import { CurrencyDto } from "../../dtos/CurrencyDto";
import { CurrentRatesInfoDto } from "../../dtos/CurrentRatesInfoDto";
import { CurrencyRow } from "./CurrencyRow";
import { CurrencyRateInfoDto } from "../../dtos/CurrencyRateInfoDto";

export interface CurrenciesProps {
  currencies: CurrencyDto[];
  ratesInfo: CurrentRatesInfoDto;
}

export interface CurrenciesState {}

export class Currencies extends React.Component<
  CurrenciesProps,
  CurrenciesState
> {
  render() {
    let rows: Array<CurrencyRow> = [];

    for (let i = 0; i < this.props.currencies.length; i++) {
      const currency = this.props.currencies[i];
      const defaultIsoCode = this.props.ratesInfo.defaultCurrency;
      const rates = this.props.ratesInfo.rates;

      let row: CurrencyRow = new CurrencyRow(currency);

      if (defaultIsoCode === currency.isoCode) {
        row.isPrimary = true;
      } else {
        const rateInfo: CurrencyRateInfoDto | undefined = rates.find(
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
