import { ABP } from '@abp/ng.core';


export namespace Pastorals {
  export interface State {
    pastorals: Response;
  }

  export interface Response {
    items: Pastoral[];
    totalCount: number;
  }



  export interface PastoralsQueryParams extends ABP.PageQueryParams {
    filterText?: string;
    monkId?: string;
    fromDateMax?: string;
    fromDateMin?: string;
    toDateMax?: string;
    toDateMin?: string;
    placeOfPastoral?: string;

  }

  export interface Pastoral {
    id: string;
    monkId: string;
    fromDate: string;
    toDate: string;
    placeOfPastoral: string;

  }

  export interface PastoralCreateUpdateDto {
    monkId: string;
    fromDate: string;
    toDate: string;
    placeOfPastoral: string;

  }
}
