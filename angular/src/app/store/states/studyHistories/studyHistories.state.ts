import { Injectable } from '@angular/core';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetStudyHistories, CreateUpdateStudyHistory, DeleteStudyHistory  } from '../../actions/studyHistories/studyHistories.action';
import { StudyHistories } from '../../models/studyHistories/studyHistories';
import { StudyHistoriesService } from 'src/app/services/studyHistories.service';
import { tap } from 'rxjs/operators';

@State<StudyHistories.State> ({
  name: 'StudyHistoriesState',
  defaults: { studyHistories: {} } as StudyHistories.State
})
@Injectable()
export class StudyHistoriesState {
  @Selector()
  static getStudyHistories(state: StudyHistories.State) {
    return state.studyHistories.items || [];
  }

  @Selector()
  static getTotalCount(state: StudyHistories.State): number {
    return state.studyHistories.totalCount || 0;
  }

  constructor(private studyHistoriesService: StudyHistoriesService) { }
    
  @Action(GetStudyHistories)
  get({ patchState }: StateContext<StudyHistories.State>, { payload }: GetStudyHistories) {
    return this.studyHistoriesService.getListByInput(payload).pipe(
      tap(studyHistoriesResponse => {
        patchState({
          studyHistories: studyHistoriesResponse,
        });
      }),
    );
  }

  @Action(CreateUpdateStudyHistory)
  save({}: StateContext<StudyHistories.State>, {id, payload}: CreateUpdateStudyHistory) {
    return id
      ? this.studyHistoriesService.updateByIdAndInput(payload, id)
      : this.studyHistoriesService.createByInput(payload);
  }

  @Action(DeleteStudyHistory)
  delete({}: StateContext<StudyHistories.State>, {id}: DeleteStudyHistory) {
    return this.studyHistoriesService.deleteById(id);
  }
}
