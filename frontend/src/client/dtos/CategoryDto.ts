import { IKeyEnabledDto } from "./IKeyEnabledDto";

export interface CategoryDto extends IKeyEnabledDto {
  domainName: string;
  name: string;
}
