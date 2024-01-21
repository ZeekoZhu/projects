import {
  Component,
  effect,
  inject,
  Injector,
  signal,
  Signal,
  untracked,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ICsvColumnMappingConfig,
  IEditConstantColumnDialogResult,
  IEditValueColumnDialogResult,
  ITransformedColumn,
} from './types';
import { MatListModule } from '@angular/material/list';
import {
  CdkDrag,
  CdkDragDrop,
  CdkDropList,
  moveItemInArray,
} from '@angular/cdk/drag-drop';
import { TransformConfigService } from './transform-config.service';
import { MatButton, MatIconButton } from '@angular/material/button';
import { NuMonacoEditorComponent } from '@ng-util/monaco-editor';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { EditConstantColumnDialogComponent } from './edit-constant-column-dialog.component';
import { nanoid } from 'nanoid';
import { ColumnDescriptionComponent } from './column-description.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { EditValueColumnDialogComponent } from './edit-value-column-dialog.component';

@Component({
  selector: 'projects-transform-config-ui',
  standalone: true,
  imports: [
    CdkDrag,
    CdkDropList,
    ColumnDescriptionComponent,
    CommonModule,
    FormsModule,
    MatButton,
    MatIconButton,
    MatIconModule,
    MatListModule,
    NuMonacoEditorComponent,
    MatMenuModule,
  ],
  templateUrl: './transform-config-ui.component.html',
})
export class TransformConfigUiComponent {
  transformConfig = inject(TransformConfigService);
  config: Signal<ICsvColumnMappingConfig> =
    this.transformConfig.state.signal('config');
  showJsonEditor = signal(false);
  editorOptions: monaco.editor.IStandaloneEditorConstructionOptions = {
    language: 'json',
  };
  editorContent = signal('');

  handleDrop($event: CdkDragDrop<ITransformedColumn>) {
    const config = this.config();
    if (!config) return;
    moveItemInArray(config.columns, $event.previousIndex, $event.currentIndex);
    this.transformConfig.updateColumns(config.columns);
  }

  @ViewChild('configEditor')
  configEditor: monaco.editor.IStandaloneCodeEditor | null = null;
  dialog = inject(MatDialog);

  constructor() {
    effect(() => {
      if (this.showJsonEditor()) {
        untracked(() => {
          const configString = this.transformConfig.configString();
          if (configString) {
            this.editorContent.set(configString);
          }
          this.configEditor?.layout();
        });
      } else {
        untracked(() => {
          this.transformConfig.setConfigString(this.editorContent());
        });
      }
    });
  }

  handleAddColumn() {
    const dialogRef = this.dialog.open(EditConstantColumnDialogComponent, {
      data: {
        name: '',
        cellValue: '',
      },
    });
    dialogRef
      .afterClosed()
      .subscribe((res: IEditConstantColumnDialogResult) => {
        if (res) {
          this.transformConfig.addColumn({
            id: nanoid(),
            ...res,
          });
        }
      });
  }

  private injector = inject(Injector);

  handleEditColumn(column: ITransformedColumn) {
    if ('cellValue' in column) {
      const dialogRef = this.dialog.open(EditConstantColumnDialogComponent, {
        data: {
          name: column.name,
          cellValue: column.cellValue,
        },
      });
      dialogRef
        .afterClosed()
        .subscribe((res: IEditConstantColumnDialogResult) => {
          this.transformConfig.updateColumn({
            ...column,
            ...res,
          });
        });
    } else if ('cellIndex' in column) {
      const dialogRef = this.dialog.open(EditValueColumnDialogComponent, {
        data: {
          name: column.name,
          cellIndex: column.cellIndex,
        },
        injector: this.injector,
      });
      dialogRef.afterClosed().subscribe((res: IEditValueColumnDialogResult) => {
        this.transformConfig.updateColumn({
          ...column,
          ...res,
        });
      });
    }
  }
}
