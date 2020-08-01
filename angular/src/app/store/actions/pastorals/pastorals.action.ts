import { Pastorals } from '../../models';

export class GetPastorals {
  static readonly type = '[Pastorals] Get';
  constructor(public payload?: Pastorals.PastoralsQueryParams) {}
}

export class CreateUpdatePastoral {
  static readonly type = '[Pastorals] Create/Update';
  constructor(public payload: Pastorals.PastoralCreateUpdateDto, public id?: string) {}
}

export class DeletePastoral {
  static readonly type = '[Pastorals] Delete';
  constructor(public id: string) {}
}
