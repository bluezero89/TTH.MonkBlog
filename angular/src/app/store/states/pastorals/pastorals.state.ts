import { Injectable } from '@angular/core';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetPastorals, CreateUpdatePastoral, DeletePastoral  } from '../../actions/pastorals/pastorals.action';
import { Pastorals } from '../../models/pastorals/pastorals';
import { PastoralsService } from 'src/app/services/pastorals.service';
import { tap } from 'rxjs/operators';

@State<Pastorals.State> ({
  name: 'PastoralsState',
  defaults: { pastorals: {} } as Pastorals.State
})
@Injectable()
export class PastoralsState {
  @Selector()
  static getPastorals(state: Pastorals.State) {
    return state.pastorals.items || [];
  }

  @Selector()
  static getTotalCount(state: Pastorals.State): number {
    return state.pastorals.totalCount || 0;
  }

  constructor(private pastoralsService: PastoralsService) { }
    
  @Action(GetPastorals)
  get({ patchState }: StateContext<Pastorals.State>, { payload }: GetPastorals) {
    return this.pastoralsService.getListByInput(payload).pipe(
      tap(pastoralsResponse => {
        patchState({
          pastorals: pastoralsResponse,
        });
      }),
    );
  }

  @Action(CreateUpdatePastoral)
  save({}: StateContext<Pastorals.State>, {id, payload}: CreateUpdatePastoral) {
    return id
      ? this.pastoralsService.updateByIdAndInput(payload, id)
      : this.pastoralsService.createByInput(payload);
  }

  @Action(DeletePastoral)
  delete({}: StateContext<Pastorals.State>, {id}: DeletePastoral) {
    return this.pastoralsService.deleteById(id);
  }
}
