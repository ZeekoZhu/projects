import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ITransformedColumn } from './types';
import { ConstantColumnDescriptionComponent } from './constant-column-description.component';
import { ValueColumnDescriptionComponent } from './value-column-description.component';

@Component({
  selector: 'projects-column-description',
  standalone: true,
  imports: [
    CommonModule,
    ConstantColumnDescriptionComponent,
    ValueColumnDescriptionComponent,
  ],
  templateUrl: './column-description.component.html',
})
export class ColumnDescriptionComponent {
  @Input({ required: true })
  column!: ITransformedColumn;

  get columnType() {
    return 'cellIndex' in this.column ? 'cellIndex' : 'cellValue';
  }
}
