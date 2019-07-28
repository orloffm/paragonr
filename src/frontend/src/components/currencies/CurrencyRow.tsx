import { CurrencyDto } from "../../dtos/CurrencyDto";
import { RowInfo } from "../common/table/RowInfo";

export class CurrencyRow implements RowInfo {
  constructor(cd: CurrencyDto) {
    this._id = cd.isoCode;
    this.isoCode = cd.isoCode;
    this.name = cd.name;
    this.symbol = cd.symbol;
    this.isPrimary = false;
  }

  _id: string;
  isoCode: string;
  name: string;
  symbol: string;
  rateToMain?: number;
  isPrimary: boolean;
  date?: string;
}
