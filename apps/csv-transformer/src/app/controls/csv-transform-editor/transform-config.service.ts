import { Injectable } from '@angular/core';
import {
  createInitialColumnMappingConfig,
  ICsvColumnMappingConfig,
  ITransformedColumn,
} from './types';
import { rxState } from '@rx-angular/state';
import { toSignal } from '@angular/core/rxjs-interop';

@Injectable()
export class TransformConfigService {
  constructor() {}

  state = rxState<State>(({ set }) => {
    set({ config: createInitialColumnMappingConfig([]), dataColumns: [] });
  });

  reset(dataColumns: string[]) {
    this.state.set({
      config: createInitialColumnMappingConfig(dataColumns),
      dataColumns: [...dataColumns],
    });
  }

  setConfigString(configStr: string) {
    let parsed = null;
    try {
      parsed = JSON.parse(configStr);
    } catch (e) {
      // ignore
    }
    if (parsed && 'columns' in parsed) {
      this.state.set({ config: parsed });
    }
  }

  configString = toSignal(
    this.state.select('config', (it) => JSON.stringify(it, null, 2))
  );

  updateColumns(columns: ITransformedColumn[]) {
    this.state.set({ config: { columns } });
  }

  addColumn(col: ITransformedColumn) {
    this.state.set({
      config: { columns: [...this.state.get().config.columns, col] },
    });
  }

  removeColumn(id: string) {
    this.state.set({
      config: {
        columns: this.state.get().config.columns.filter((it) => it.id !== id),
      },
    });
  }
}

interface State {
  config: ICsvColumnMappingConfig;
  dataColumns: string[];
}
