import { IKeyEnabledDto } from "./IKeyEnabledDto";

export interface DomainDto extends IKeyEnabledDto {
  defaultCategoryName: string;
  name: string;
}
