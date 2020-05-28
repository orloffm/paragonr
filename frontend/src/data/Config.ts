export interface Config {
  baseApiUrl: string;
}

// Used when debugging locally.
const DevelopmentConfigValue: Config = {
  baseApiUrl: "http://localhost:5002/api",
};

// Production.
const ProductionConfigValue: Config = {
  baseApiUrl: "https://api.paragonr.com/api",
};

export function getConfig(): Config {
  let env = process.env.NODE_ENV;

  if (env == "production") return ProductionConfigValue;
  else return DevelopmentConfigValue;
}
