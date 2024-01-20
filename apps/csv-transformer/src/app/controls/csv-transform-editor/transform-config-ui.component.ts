import { Component, effect, inject, signal, Signal, untracked, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ICsvColumnMappingConfig } from './types';
import { MatList, MatListItem, MatListItemLine, MatListItemTitle } from '@angular/material/list';
import { CdkDrag, CdkDragDrop, CdkDropList, moveItemInArray } from '@angular/cdk/drag-drop';
import { TransformConfigService } from './transform-config.service';
import { MatButton } from '@angular/material/button';
import { NuMonacoEditorComponent } from '@ng-util/monaco-editor';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'projects-transform-config-ui',
  standalone: true,
  imports: [ CommonModule, MatListItem, MatList, MatListItemLine, MatListItemTitle, CdkDropList, CdkDrag, MatButton,
    NuMonacoEditorComponent, FormsModule ],
  templateUrl: './transform-config-ui.component.html',
})
export class TransformConfigUiComponent {
  transformConfig = inject(TransformConfigService);
  config: Signal<ICsvColumnMappingConfig> = this.transformConfig.state.signal('config');
  showJsonEditor = signal(false);
  editorOptions: monaco.editor.IStandaloneEditorConstructionOptions = {
    language: 'json'
  };
  editorContent = signal('');

  handleDrop($event: CdkDragDrop<any, any>) {
    const config = this.config();
    if (!config) return;
    moveItemInArray(config.columns, $event.previousIndex, $event.currentIndex);
    this.transformConfig.updateColumns(config.columns);
  }

  @ViewChild('configEditor')
  configEditor: monaco.editor.IStandaloneCodeEditor | null = null;

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
      }else{
        untracked(()=>{
          this.transformConfig.setConfigString(this.editorContent());
        })
      }
    });
  }
}

