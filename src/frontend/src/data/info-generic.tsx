const currenciesData = {
  categories: [],
  currencies: [
    { isoCode: "PLN", name: "Polish złoty", symbol: "zł" },
    { isoCode: "USD", name: "US dollar", symbol: "$" },
    { isoCode: "EUR", name: "Euro", symbol: "€" },
    { isoCode: "RUB", name: "Russian ruble", symbol: "₽" }
  ],
  domains: [],
  ratesInfo: {
    defaultCurrency: "PLN",
    rates: [
      { date: "2019-07-14T00:00:00", isoCode: "USD", rate: 3.79 },
      { date: "2019-07-14T00:00:00", isoCode: "EUR", rate: 4.28 },
      { date: "2019-07-14T00:00:00", isoCode: "RUB", rate: 0.060129 }
    ]
  }
};

export default currenciesData;
