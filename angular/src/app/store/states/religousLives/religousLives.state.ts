import { Injectable } from '@angular/core';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetReligousLives, CreateUpdateReligousLife, DeleteReligousLife  } from '../../actions/religousLives/religousLives.action';
import { ReligousLives } from '../../models/religousLives/religousLives';
import { ReligousLivesService } from 'src/app/services/religousLives.service';
import { tap } from 'rxjs/operators';

@State<ReligousLives.State> ({
  name: 'ReligousLivesState',
  defaults: { religousLives: {} } as ReligousLives.State
})
@Injectable()
export class ReligousLivesState {
  @Selector()
  static getReligousLives(state: ReligousLives.State) {
    return state.religousLives.items || [];
  }

  @Selector()
  static getTotalCount(state: ReligousLives.State): number {
    return state.religousLives.totalCount || 0;
  }

  constructor(private religousLivesService: ReligousLivesService) { }
    
  @Action(GetReligousLives)
  get({ patchState }: StateContext<ReligousLives.State>, { payload }: GetReligousLives) {
    return this.religousLivesService.getListByInput(payload).pipe(
      tap(religousLivesResponse => {
        patchState({
          religousLives: religousLivesResponse,
        });
      }),
    );
  }

  @Action(CreateUpdateReligousLife)
  save({}: StateContext<ReligousLives.State>, {id, payload}: CreateUpdateReligousLife) {
    return id
      ? this.religousLivesService.updateByIdAndInput(payload, id)
      : this.religousLivesService.createByInput(payload);
  }

  @Action(DeleteReligousLife)
  delete({}: StateContext<ReligousLives.State>, {id}: DeleteReligousLife) {
    return this.religousLivesService.deleteById(id);
  }
}
