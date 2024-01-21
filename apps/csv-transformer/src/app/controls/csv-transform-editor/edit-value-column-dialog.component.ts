import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {IEditValueColumnDialogData } from './types';
import { TransformConfigService } from './transform-config.service';
import { toSignal } from '@angular/core/rxjs-interop';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import {MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'projects-edit-value-column',
  standalone: true,
  imports: [ CommonModule, MatDialogModule, MatFormFieldModule, FormsModule, ReactiveFormsModule, MatInput, MatButton,
    MatSelectModule ],
  templateUrl: './edit-value-column-dialog.component.html'
})
export class EditValueColumnDialogComponent {
  data = inject(MAT_DIALOG_DATA) as IEditValueColumnDialogData;
  transformConfig = inject(TransformConfigService);
  dataColumns = toSignal(this.transformConfig.state.select('dataColumns'));
  columnOptions = computed(() => this.dataColumns()?.map((it,idx) => ({ label: it, value: idx })) ?? []);
  fb= inject(FormBuilder);
  form = this.fb.group({
    name: [ this.data.name ],
    cellIndex: [ this.data.cellIndex ]
  });
}
