import {
  AfterViewInit,
  Component,
  computed,
  effect,
  signal,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import Papa from 'papaparse';
import { SelectionModel } from '@angular/cdk/collections';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatPaginator } from '@angular/material/paginator';
import { MatTab, MatTabGroup } from '@angular/material/tabs';
import { map } from 'rxjs';
import { rxState } from '@rx-angular/state';
import { CsvTransformEditorComponent } from '../controls/csv-transform-editor/csv-transform-editor.component';

@Component({
  selector: 'projects-home-page',
  standalone: true,
  imports: [
    CommonModule,
    MatLabel,
    MatFormField,
    MatInput,
    MatButton,
    MatTableModule,
    MatCheckbox,
    MatPaginator,
    MatTabGroup,
    MatTab,
    CsvTransformEditorComponent,
  ],
  templateUrl: './home-page.component.html',
})
export class HomePageComponent implements AfterViewInit {
  sourceFile = signal<File | null>(null);
  fileName = computed(() => this.sourceFile()?.name ?? 'No file selected');
  handleFileSelect = (event: Event) => {
    this.sourceFile.set((event.target as HTMLInputElement).files?.[0] ?? null);
  };
  fileContent = signal('');
  parsedCsv = computed((): string[][] => {
    if (!this.fileContent()) return [];
    return Papa.parse(this.fileContent()).data as string[][];
  });
  dataColumns = computed((): string[] => {
    return this.parsedCsv()[0] ?? [];
  });
  displayColumns = computed((): string[] => ['select', ...this.dataColumns()]);
  allRowsButFirst = computed((): string[][] => {
    return this.parsedCsv().slice(1);
  });
  selection = new SelectionModel<string[]>(true, []);

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.allRowsButFirst().length;
    return numSelected == numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  toggleAllRows() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.allRowsButFirst().forEach((row) => this.selection.select(row));
  }

  state = rxState<State>(({ set }) => {
    set({ selectedRows: [] });
  });

  dataSource = new MatTableDataSource<string[]>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  selectedRows = this.state.signal('selectedRows');

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor() {
    effect(() => {
      this.sourceFile()
        ?.text()
        .then((text) => this.fileContent.set(text));
    });

    effect(() => {
      this.dataSource.data = this.allRowsButFirst();
    });
    const selectedChanges$ = this.selection.changed.pipe(
      map((it) => it.source.selected)
    );
    effect(() => {
      void this.parsedCsv();
      this.selection.clear();
    });
    this.state.connect('selectedRows', selectedChanges$);
  }

  setTableFilter(event: Event) {
    this.dataSource.filter = (event.target as HTMLInputElement).value
      .trim()
      .toLowerCase();
  }
}

interface State {
  selectedRows: string[][];
}
