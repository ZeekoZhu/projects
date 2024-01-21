import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IConstantColumn, IValueColumn } from './types';

@Component({
  selector: 'projects-constant-column-description',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './constant-column-description.component.html',
})
export class ConstantColumnDescriptionComponent {
  @Input({
    transform: (value: IConstantColumn | IValueColumn): IConstantColumn =>
      value as IConstantColumn,
  })
  column!: IConstantColumn;
}
