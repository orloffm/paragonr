import React, { Component } from "react";
import _ from "lodash";
import { ColumnInfo } from "./ColumnInfo";

export interface TableBodyProps {
  data: Array<any>;
  columns: Array<ColumnInfo>;
}

export interface TableBodyState {}

class TableBody extends React.Component<TableBodyProps, TableBodyState> {
  renderCell = (item: any, column: ColumnInfo) => {
    if (column.content) return column.content(item);

    if (column.path) return _.get(item, column.path);

    return "";
  };

  createKey = (item: any, column: ColumnInfo) => {
    return item._id + (column.path || column.key);
  };

  render() {
    const { data, columns } = this.props;

    return (
      <tbody>
        {data.map((item: { _id: number }) => (
          <tr key={item._id}>
            {columns.map((column: any) => (
              <td key={this.createKey(item, column)}>
                {this.renderCell(item, column)}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    );
  }
}

export default TableBody;
