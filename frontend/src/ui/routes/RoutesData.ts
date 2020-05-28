import { RouteComponentProps } from "react-router";
import { Currencies } from "../pages/Currencies";
import { Categories } from "../pages/Categories";
import { Spendings } from "../pages/Spendings";
import { NotFound } from "../pages/NotFound";
import { LoginPage } from "../pages/Login";
import { Info } from "../pages/Info";
import Home from "../pages/Home";

// Represents all routing possibilities - keys and components.
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
  title: string;
  allowAnonymous?: boolean;
  onlyAnonymous?: boolean;
}

export const AppRoutes: RoutesData = {
  notFoundKey: "not-found",
  loginKey: "login",
  homeKey: "",
  homeComponent: Home,
  notFoundComponent: NotFound,
  routes: [
    {
      key: "login",
      title: "Login",
      component: LoginPage,
      allowAnonymous: true,
      onlyAnonymous: true
    },
    {
      key: "currencies",
      title: "Currencies",
      component: Currencies
    },
    {
      key: "categories",
      title: "Categories",
      component: Categories
    },
    {
      key: "spendings",
      title: "Spendings",
      component: Spendings
    },
    {
      key: "info",
      title: "Info",
      component: Info,
      allowAnonymous: true,
      onlyAnonymous: false
    }
  ]
};
