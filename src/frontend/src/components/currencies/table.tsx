import React from "react";
import TableWrapped from "../common/table/tableWrapped";
import { ColumnInfo } from "../common/table/ColumnInfo";
import { SortColumnInfo } from "../common/table/SortColumnInfo";
import _ from "lodash";
import { CurrencyRow } from "./CurrencyRow";

export interface CurrenciesTableProps {
  data: CurrencyRow[];
}

export interface CurrenciesTableState {
  sortColumn: SortColumnInfo;
}

class CurrenciesTable extends React.Component<
  CurrenciesTableProps,
  CurrenciesTableState
> {
  state: CurrenciesTableState = {
    sortColumn: {
      path: "isoCode",
      order: "asc"
    }
  };

  columns: Array<ColumnInfo> = [
    { path: "isoCode", label: "Code" },
    { path: "symbol", label: "Symbol" },
    { path: "name", label: "Name" },
    { path: "rateToMain", label: "Rate" },
    { path: "date", label: "Date" }
  ];

  onSort = (what: SortColumnInfo) => {
    this.setState({ sortColumn: what });
  };

  render() {
    const { data } = this.props;
    const { sortColumn } = this.state;

    const sorted = _.orderBy(data, [sortColumn.path], [sortColumn.order]);

    return (
      <TableWrapped
        columns={this.columns}
        data={sorted}
        sortColumn={sortColumn}
        onSort={path => this.onSort(path)}
      />
    );
  }
}

export default CurrenciesTable;
