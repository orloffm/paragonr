import * as React from "react";
import { Component } from "react";

export interface NotFoundProps {}

export interface NotFoundState {}

class NotFound extends React.Component<NotFoundProps, NotFoundState> {
  render() {
    return "NotFound.";
  }
}

export default NotFound;
