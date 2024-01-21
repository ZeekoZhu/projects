import {
  AfterViewInit,
  Component,
  computed,
  effect,
  inject,
  Input,
  Signal,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTab, MatTabGroup } from '@angular/material/tabs';
import Papa from 'papaparse';
import { NuMonacoEditorComponent } from '@ng-util/monaco-editor';
import { FormsModule } from '@angular/forms';
import { TransformConfigUiComponent } from './transform-config-ui.component';
import { TransformConfigService } from './transform-config.service';

@Component({
  selector: 'projects-csv-transform-editor',
  standalone: true,
  providers: [TransformConfigService],
  imports: [
    CommonModule,
    MatTab,
    MatTabGroup,
    NuMonacoEditorComponent,
    FormsModule,
    TransformConfigUiComponent,
  ],
  templateUrl: './csv-transform-editor.component.html',
})
export class CsvTransformEditorComponent implements AfterViewInit {
  transformConfig = inject(TransformConfigService);
  @Input({ required: true })
  data!: Signal<string[][]>;
  @Input({ required: true })
  dataColumns!: Signal<string[]>;
  previewOptions: monaco.editor.IStandaloneEditorConstructionOptions = {
    language: 'csv',
    readOnly: true,
  };

  get config() {
    return this.transformConfig.state.signal('config');
  }

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
        this.transformConfig.reset(this.dataColumns());
      },
      {
        allowSignalWrites: true,
      }
    );
  }

  ngAfterViewInit(): void {
    this.configEditorRef?.editor?.layout();
  }
}
