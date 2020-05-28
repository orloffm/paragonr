import * as React from "react";

export interface InfoProps {}

export interface InfoState {}

export class Info extends React.Component<InfoProps, InfoState> {
  render() {
    return (
      <React.Fragment>
        <h1>Info</h1>
        <p>
          You are running this application in <b>{process.env.NODE_ENV}</b> mode.
        </p>
      </React.Fragment>
    );
  }
}
