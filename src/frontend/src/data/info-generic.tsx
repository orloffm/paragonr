const currenciesData = {
  categories: [
    { domainName: "Дети", name: "-" },
    { domainName: "Машина", name: "Бензин" },
    { domainName: "Машина", name: "-" },
    { domainName: "Коты", name: "-" },
    { domainName: "Жизнь", name: "Чтение" },
    { domainName: "Жизнь", name: "Одежда" },
    { domainName: "Жизнь", name: "Транспорт" },
    { domainName: "Жизнь", name: "Страховка" },
    { domainName: "Жизнь", name: "Сервисы" },
    { domainName: "Жизнь", name: "Развлечения" },
    { domainName: "Машина", name: "Парковка" },
    { domainName: "Жизнь", name: "Путешествия" },
    { domainName: "Жизнь", name: "Квартира" },
    { domainName: "Жизнь", name: "-" },
    { domainName: "Еда", name: "Снэки" },
    { domainName: "Еда", name: "Рестораны" },
    { domainName: "Еда", name: "-" },
    { domainName: "Дети", name: "Развлечения" },
    { domainName: "Дети", name: "Подгузники" },
    { domainName: "Дети", name: "Еда" },
    { domainName: "Дети", name: "Одежда" },
    { domainName: "Жизнь", name: "Медицина" },
    { domainName: "Машина", name: "Обслуживание" }
  ],
  currencies: [
    { isoCode: "PLN", name: "Polish złoty", symbol: "zł" },
    { isoCode: "USD", name: "US dollar", symbol: "$" },
    { isoCode: "EUR", name: "Euro", symbol: "€" },
    { isoCode: "RUB", name: "Russian ruble", symbol: "₽" }
  ],
  domains: [
    { defaultCategoryName: "-", name: "Дети" },
    { defaultCategoryName: "-", name: "Еда" },
    { defaultCategoryName: "-", name: "Жизнь" },
    { defaultCategoryName: "-", name: "Коты" },
    { defaultCategoryName: "-", name: "Машина" }
  ],
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
