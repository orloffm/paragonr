export interface CurrencyDto {
  isoCode: string;
  name: string;
  symbol: string;
}

export interface CategoryDto {
  domainName: string;
  name: string;
}

export interface DomainDto {
  defaultCategoryName: string;
  name: string;
}
