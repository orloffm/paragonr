import { RowInfo } from "../common/Table/RowInfo";
import { CategoryDto } from "../../../client/dtos/CategoryDto";

export class CategoryRow implements RowInfo {
  constructor(cd: CategoryDto) {
    this.key = cd.key;
    this.name = cd.name;
    this.domainName = cd.domainName;
    this.isPrimary = false;
  }

  key: string;
  domainName: string;
  name: string;
  isPrimary: boolean;
}
