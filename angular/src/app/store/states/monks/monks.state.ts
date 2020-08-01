import { Injectable } from '@angular/core';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetMonks, CreateUpdateMonk, DeleteMonk  } from '../../actions/monks/monks.action';
import { Monks } from '../../models/monks/monks';
import { MonksService } from 'src/app/services/monks.service';
import { tap } from 'rxjs/operators';

@State<Monks.State> ({
  name: 'MonksState',
  defaults: { monks: {} } as Monks.State
})
@Injectable()
export class MonksState {
  @Selector()
  static getMonks(state: Monks.State) {
    return state.monks.items || [];
  }

  @Selector()
  static getTotalCount(state: Monks.State): number {
    return state.monks.totalCount || 0;
  }

  constructor(private monksService: MonksService) { }
    
  @Action(GetMonks)
  get({ patchState }: StateContext<Monks.State>, { payload }: GetMonks) {
    return this.monksService.getListByInput(payload).pipe(
      tap(monksResponse => {
        patchState({
          monks: monksResponse,
        });
      }),
    );
  }

  @Action(CreateUpdateMonk)
  save({}: StateContext<Monks.State>, {id, payload}: CreateUpdateMonk) {
    return id
      ? this.monksService.updateByIdAndInput(payload, id)
      : this.monksService.createByInput(payload);
  }

  @Action(DeleteMonk)
  delete({}: StateContext<Monks.State>, {id}: DeleteMonk) {
    return this.monksService.deleteById(id);
  }
}
