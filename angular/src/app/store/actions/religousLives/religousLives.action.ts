import { ReligousLives } from '../../models';

export class GetReligousLives {
  static readonly type = '[ReligousLives] Get';
  constructor(public payload?: ReligousLives.ReligousLivesQueryParams) {}
}

export class CreateUpdateReligousLife {
  static readonly type = '[ReligousLives] Create/Update';
  constructor(public payload: ReligousLives.ReligousLifeCreateUpdateDto, public id?: string) {}
}

export class DeleteReligousLife {
  static readonly type = '[ReligousLives] Delete';
  constructor(public id: string) {}
}
