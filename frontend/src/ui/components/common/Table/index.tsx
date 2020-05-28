import React from "react";
import TableHeader from "./tableHeader";
import TableBody from "./tableBody";
import { ColumnInfo } from "./ColumnInfo";
import { SortColumnInfo } from "./SortColumnInfo";
import { RowInfo } from "./RowInfo";

export interface TableProps {
  columns: Array<ColumnInfo>;
  sortColumn?: SortColumnInfo;
  onSort?(what: SortColumnInfo): void;
  data: Array<RowInfo>;
}

export interface TableState {}

class TableWrapped extends React.Component<TableProps, TableState> {
  render() {
    const { columns, sortColumn, onSort, data } = this.props;

    return (
      <table className="table">
        <TableHeader
          columns={columns}
          sortColumn={sortColumn}
          onSort={onSort}
        />
        <TableBody columns={columns} data={data} />
      </table>
    );
  }
}

export default TableWrapped;
