import React from "react";
import { Route, Redirect, RouteProps } from "react-router-dom";

export interface PrivateRoutePlainProps extends RouteProps {
  isLoggedIn: boolean;
  loginPath: string;
}

class PrivateRoutePlain extends React.Component<PrivateRoutePlainProps> {
  render() {
    const currentUser = this.props.isLoggedIn; // authenticationService.currentUserValue;
    if (!currentUser) {
      // not logged in so redirect to login page with the return url
      return (
        <Redirect
          to={{ pathname: this.props.loginPath, state: { from: this.props.location } }}
        />
      );
    }

    // check if route is restricted by role
    // if (roles && roles.indexOf(currentUser.role) === -1) {
    //     // role not authorised so redirect to home page
    //     return <Redirect to={{ pathname: '/'}} />
    // }

    // authorised so return component
    return <Route {...this.props} />;
  }
}

export { PrivateRoutePlain };
