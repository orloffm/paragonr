import React from "react";
import TableWrapped from "../common/table/tableWrapped";
import { ColumnInfo } from "../common/table/ColumnInfo";
import _ from "lodash";
import { CategoryRow } from "./CategoryRow";

export interface CategoriesTableProps {
  data: CategoryRow[];
}

export interface CategoriesTableState {}

class CategoriesTable extends React.Component<
  CategoriesTableProps,
  CategoriesTableState
> {
  columns: Array<ColumnInfo> = [
    { path: "domainName", label: "Domain" },
    { path: "name", label: "Category" }
  ];

  render() {
    const data = _.orderBy(
      this.props.data,
      ["domainName", "name"],
      ["asc", "asc"]
    );

    return <TableWrapped columns={this.columns} data={data} />;
  }
}

export default CategoriesTable;
