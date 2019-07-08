import * as React from "react";
import { Component } from "react";

export interface SpendingsProps {}

export interface SpendingsState {}

class Spendings extends React.Component<SpendingsProps, SpendingsState> {
  state = {};
  render() {
    return (
      <div>
        <table>
          <thead>
            <tr>
              <th>Day</th>
              <th>Where</th>
              <th>What</th>
              <th>Sum</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td />
              <td />
              <td />
              <td />
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}

export default Spendings;
