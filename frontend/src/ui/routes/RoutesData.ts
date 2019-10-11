import { RouteComponentProps } from "react-router";
import { Currencies } from "../pages/Currencies";
import { Categories } from "../pages/Categories";
import { Spendings } from "../pages/Spendings";
import { NotFound } from "../pages/NotFound";
import { LoginPage } from "../pages/Login";
import Home from "../pages/Home";

export interface RoutesData {
  notFoundKey: string;
  loginKey: string;
  homeKey: string;
  homeComponent: React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;
  notFoundComponent:
    | React.ComponentType<RouteComponentProps<any>>
    | React.ComponentType<any>;
  routes: RouteData[];
}

export interface RouteData {
  component: React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;
  key: string;
  exact?: boolean;
  public?: boolean;
}

export const AppRoutes: RoutesData = {
  notFoundKey: "not-found",
  loginKey: "login",
  homeKey: "home",
  homeComponent: Home,
  notFoundComponent: NotFound,
  routes: [
    {
      key: "login",
      component: LoginPage,
      public: true
    },
    {
      key: "currencies",
      component: Currencies
    },
    {
      key: "categories",
      component: Categories
    },
    {
      key: "spendings",
      component: Spendings
    }
  ]
};
