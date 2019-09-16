import * as React from "react";
import { Component } from "react";

export interface NotFoundProps {}

export interface NotFoundState {}

export class NotFound extends React.Component<NotFoundProps, NotFoundState> {
  render() {
    return "NotFound.";
  }
}
