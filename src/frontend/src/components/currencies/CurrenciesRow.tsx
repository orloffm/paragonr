import { CurrenciesData } from "../../dtos/CurrenciesData";

export class CurrenciesRow {
  constructor(cd: CurrenciesData) {
    this.isoCode = cd.isoCode;
    this.name = cd.name;
    this.symbol = cd.symbol;
    this.isMain = false;
  }

  isoCode: string;
  name: string;
  symbol: string;
  rateToMain?: number;
  isMain: boolean;
  date?: Date;
}
