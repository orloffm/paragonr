import * as React from "react";

export interface NotFoundProps {}

export interface NotFoundState {}

export class NotFound extends React.Component<NotFoundProps, NotFoundState> {
  render() {
    return <h1>Not Found</h1>;
  }
}
