import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
} from '@angular/material/dialog';
import { IEditConstantColumnDialogData } from './types';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'projects-edit-column-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatLabel,
    MatFormField,
    MatSelect,
    MatOption,
    MatInput,
    MatDialogContent,
    MatDialogClose,
    MatDialogActions,
    MatButton,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './edit-constant-column-dialog.component.html',
})
export class EditConstantColumnDialogComponent {
  data = inject(MAT_DIALOG_DATA) as IEditConstantColumnDialogData;
  fb = inject(FormBuilder);
  form = this.fb.group({
    name: [this.data.name],
    cellValue: [this.data.cellValue],
  });
}
