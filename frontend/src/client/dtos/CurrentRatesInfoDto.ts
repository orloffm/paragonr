import { CurrencyRateInfoDto } from "./CurrencyRateInfoDto";

export interface CurrentRatesInfoDto {
  defaultCurrency: string;
  rates: CurrencyRateInfoDto[];
}
