import * as React from "react";
import { DomainDto } from "../../dtos/DomainDto";
import { CategoryDto } from "../../dtos/CategoryDto";
import { CategoryRow } from "./CategoryRow";
import CategoriesTable from "./table";

export interface CategoriesProps {
  categories: CategoryDto[];
  domains: DomainDto[];
}

export interface CategoriesState {}

class Categories extends React.Component<CategoriesProps, CategoriesState> {
  render() {
    let rows: Array<CategoryRow> = [];

    for (let i = 0; i < this.props.categories.length; i++) {
      const category = this.props.categories[i];

      let row: CategoryRow = new CategoryRow(category);

      rows.push(row);
    }

    return <CategoriesTable data={rows} />;
  }
}

export default Categories;
