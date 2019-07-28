import React from "react";
import { SortColumnInfo } from "./SortColumnInfo";
import { ColumnInfo } from "./ColumnInfo";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSortUp, faSortDown } from "@fortawesome/free-solid-svg-icons";

export interface TableHeaderProps {
  columns: Array<ColumnInfo>;
  sortColumn?: SortColumnInfo;
  onSort?(what: SortColumnInfo): void;
}

export interface TableHeaderState {}

class TableHeader extends React.Component<TableHeaderProps, TableHeaderState> {
  raiseSort = (path: string | undefined) => {
    const sortColumn = this.props.sortColumn;
    if (sortColumn === undefined) return;
    if (this.props.onSort === undefined) return;
    if (path === undefined) return;

    if (sortColumn.path === path)
      sortColumn.order = sortColumn.order === "asc" ? "desc" : "asc";
    else {
      sortColumn.path = path;
      sortColumn.order = "asc";
    }
    this.props.onSort(sortColumn);
  };

  renderSortIcon = (column: ColumnInfo) => {
    const sortColumn = this.props.sortColumn;
    if (sortColumn === undefined) return;

    if (column.path !== sortColumn.path) return null;
    return (
      <FontAwesomeIcon
        icon={sortColumn.order === "asc" ? faSortUp : faSortDown}
      />
    );
  };

  render() {
    return (
      <thead>
        <tr>
          {this.props.columns.map(column => (
            <th
              className="clickable"
              key={column.path || column.key}
              onClick={() => {
                this.raiseSort(column.path);
              }}
            >
              {column.label} {this.renderSortIcon(column)}
            </th>
          ))}
        </tr>
      </thead>
    );
  }
}

export default TableHeader;
