import { Component, computed, inject, Input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IConstantColumn, IValueColumn } from './types';
import { TransformConfigService } from './transform-config.service';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'projects-value-column-description',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './value-column-description.component.html',
})
export class ValueColumnDescriptionComponent {
  transformConfig = inject(TransformConfigService);
  columns = toSignal(this.transformConfig.state.select('dataColumns'));

  @Input({
    transform: (value: IConstantColumn | IValueColumn): IValueColumn =>
      value as IValueColumn,
    required: true,
  })
  set column(value: IValueColumn) {
    this._column.set(value);
  }

  _column = signal<null | IValueColumn>(null);
  displayName = computed(() => {
    const index = this._column()!.cellIndex;
    const column = this.columns()?.[index];
    return column || index;
  });
}
