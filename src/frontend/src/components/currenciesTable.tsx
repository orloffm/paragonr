import React from "react";
import TableWrapped from "./common/table/tableWrapped";
import { CurrenciesData } from "./currenciesData";
import { ColumnInfo } from "./common/table/ColumnInfo";
import { SortColumnInfo } from "./common/table/SortColumnInfo";
import _ from "lodash";

export interface CurrenciesTableProps {
  data: CurrenciesData[];
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
    { path: "id", label: "No" },
    { path: "isoCode", label: "Code" },
    { path: "symbol", label: "Symbol" },
    { path: "name", label: "Name" }
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
