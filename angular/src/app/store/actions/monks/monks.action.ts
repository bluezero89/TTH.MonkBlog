import { Monks } from '../../models';

export class GetMonks {
  static readonly type = '[Monks] Get';
  constructor(public payload?: Monks.MonksQueryParams) {}
}

export class CreateUpdateMonk {
  static readonly type = '[Monks] Create/Update';
  constructor(public payload: Monks.MonkCreateUpdateDto, public id?: string) {}
}

export class DeleteMonk {
  static readonly type = '[Monks] Delete';
  constructor(public id: string) {}
}
