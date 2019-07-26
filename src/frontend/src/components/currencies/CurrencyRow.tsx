import { CurrencyDto } from "../../dtos/CurrencyDto";

export class CurrencyRow {
  constructor(cd: CurrencyDto) {
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
  date?: string;
}
