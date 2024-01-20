import {
  AfterViewInit,
  Component,
  computed,
  effect,
  Input,
  signal,
  Signal,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTab, MatTabGroup } from '@angular/material/tabs';
import Papa from 'papaparse';
import { NuMonacoEditorComponent } from '@ng-util/monaco-editor';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'projects-csv-transform-editor',
  standalone: true,
  imports: [
    CommonModule,
    MatTab,
    MatTabGroup,
    NuMonacoEditorComponent,
    FormsModule,
  ],
  templateUrl: './csv-transform-editor.component.html',
})
export class CsvTransformEditorComponent implements AfterViewInit {
  @Input({ required: true })
  data!: Signal<string[][]>;
  @Input({ required: true })
  dataColumns!: Signal<string[]>;
  editorOptions: monaco.editor.IStandaloneEditorConstructionOptions = {
    language: 'json',
  };
  previewOptions: monaco.editor.IStandaloneEditorConstructionOptions = {
    language: 'csv',
    readOnly: true,
  };
  transformedData = computed(() => {
    const { columns } = this.config();
    return this.data().map((row) => {
      return columns.map((column) => {
        if ('cellValue' in column) {
          return column.cellValue;
        } else {
          return row[column.cellIndex];
        }
      });
    });
  });

  configString = signal<string>('');
  config = computed((): ICsvColumnMappingConfig => {
    try {
      const result = JSON.parse(this.configString());
      if ('columns' in result) return result;
      return createInitialColumnMappingConfig(this.dataColumns());
    } catch {
      return createInitialColumnMappingConfig(this.dataColumns());
    }
  });

  transformedCsvString = computed(() => {
    const data = [
      this.config().columns.map((column) => column.name),
      ...this.transformedData(),
    ];
    return Papa.unparse(data);
  });

  @ViewChild('previewEditor')
  previewEditorRef?: NuMonacoEditorComponent;
  @ViewChild('configEditor')
  configEditorRef?: NuMonacoEditorComponent;

  constructor() {
    effect(
      () => {
        this.configString.set(
          JSON.stringify(
            createInitialColumnMappingConfig(this.dataColumns()),
            null,
            2
          )
        );
      },
      {
        allowSignalWrites: true,
      }
    );
  }

  ngAfterViewInit(): void {
    this.configEditorRef?.editor?.layout();
  }

  handleTabChange() {
    if (this.previewEditorRef) {
      this.previewEditorRef.editor?.layout();
    }
  }
}

type IConstantColumn = { name: string; cellValue: string };
type IValueColumn = { name: string; cellIndex: number };

type ITransformedColumn = IConstantColumn | IValueColumn;

interface ICsvColumnMappingConfig {
  columns: ITransformedColumn[];
}

function createInitialColumnMappingConfig(
  dataColumns: string[]
): ICsvColumnMappingConfig {
  return {
    columns: dataColumns.map((columnName) => ({
      name: columnName,
      cellIndex: dataColumns.indexOf(columnName),
    })),
  };
}
