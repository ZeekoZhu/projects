import { nanoid } from 'nanoid';

export type IConstantColumn = { id: string; name: string; cellValue: string };
export type IValueColumn = { id: string; name: string; cellIndex: number };
export type ITransformedColumn = IConstantColumn | IValueColumn;

export interface ICsvColumnMappingConfig {
  columns: ITransformedColumn[];
}

export function createInitialColumnMappingConfig(
  dataColumns: string[]
): ICsvColumnMappingConfig {
  return {
    columns: dataColumns.map((columnName) => ({
      name: columnName,
      id: nanoid(),
      cellIndex: dataColumns.indexOf(columnName),
    })),
  };
}

export interface IEditConstantColumnDialogData
  extends Pick<IConstantColumn, 'name' | 'cellValue'> {}

export interface IEditConstantColumnDialogResult {
  name: string;
  cellValue: string;
}
