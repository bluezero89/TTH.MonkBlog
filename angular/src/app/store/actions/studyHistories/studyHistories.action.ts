import { StudyHistories } from '../../models';

export class GetStudyHistories {
  static readonly type = '[StudyHistories] Get';
  constructor(public payload?: StudyHistories.StudyHistoriesQueryParams) {}
}

export class CreateUpdateStudyHistory {
  static readonly type = '[StudyHistories] Create/Update';
  constructor(public payload: StudyHistories.StudyHistoryCreateUpdateDto, public id?: string) {}
}

export class DeleteStudyHistory {
  static readonly type = '[StudyHistories] Delete';
  constructor(public id: string) {}
}
