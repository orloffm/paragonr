import React, { Component } from "react";
import _ from "lodash";
import { ColumnInfo } from "./ColumnInfo";
import { RowInfo } from "./RowInfo";

export interface TableBodyProps {
  data: Array<RowInfo>;
  columns: Array<ColumnInfo>;
}

export interface TableBodyState {}

class TableBody extends React.Component<TableBodyProps, TableBodyState> {
  renderCell = (item: RowInfo, column: ColumnInfo) => {
    if (column.content) return column.content(item);

    if (column.path) return _.get(item, column.path);

    return "";
  };

  createKey = (item: RowInfo, column: ColumnInfo) => {
    return item.key + (column.path || column.key);
  };

  getRowClass = (item: RowInfo) => {
    if (item.isPrimary) return "table-primary";

    return "";
  };

  render() {
    const { data, columns } = this.props;

    return (
      <tbody>
        {data.map(item => (
          <tr key={item.key} className={this.getRowClass(item)}>
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
