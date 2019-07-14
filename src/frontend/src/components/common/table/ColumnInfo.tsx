export interface ColumnInfo {
  label: string;
  key?: string;
  path: string;
  content?(source: any): JSX.Element;
}
