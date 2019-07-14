import React from "react";
import TableHeader from "./tableHeader";
import TableBody from "./tableBody";
import { ColumnInfo } from "./ColumnInfo";
import { SortColumnInfo } from "./SortColumnInfo";
import Table from "react-bootstrap/Table";

export interface TableProps {
  columns: Array<ColumnInfo>;
  sortColumn: SortColumnInfo;
  onSort(what: SortColumnInfo): void;
  data: Array<any>;
}

export interface TableState {}

class TableWrapped extends React.Component<TableProps, TableState> {
  render() {
    const { columns, sortColumn, onSort, data } = this.props;

    return (
      <Table striped bordered>
        <TableHeader
          columns={columns}
          sortColumn={sortColumn}
          onSort={onSort}
        />
        <TableBody columns={columns} data={data} />
      </Table>
    );
  }
}

export default TableWrapped;
