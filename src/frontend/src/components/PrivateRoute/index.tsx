import React from 'react';
import { Route, Redirect, RouteProps } from 'react-router-dom';

export interface PrivateRouteProps extends RouteProps {
    isLoggedIn: boolean;
}
  
class PrivateRoute extends React.Component<PrivateRouteProps> {
    render() { 
        const currentUser = this.props.isLoggedIn; // authenticationService.currentUserValue;
        if (!currentUser) {
            // not logged in so redirect to login page with the return url
            return <Redirect to={{ pathname: '/login', state: { from: this.props.location } }} />
        }

        // check if route is restricted by role
        // if (roles && roles.indexOf(currentUser.role) === -1) {
        //     // role not authorised so redirect to home page
        //     return <Redirect to={{ pathname: '/'}} />
        // }

        // authorised so return component
        return <Route {...this.props} />
    }
}
 
export { PrivateRoute };