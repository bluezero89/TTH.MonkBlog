import { ABP } from '@abp/ng.core';


export namespace StudyHistories {
  export interface State {
    studyHistories: Response;
  }

  export interface Response {
    items: StudyHistory[];
    totalCount: number;
  }



  export interface StudyHistoriesQueryParams extends ABP.PageQueryParams {
    filterText?: string;
    diploma?: string;
    academicLevel?: string;
    studyAt?: string;
    fromDateMax?: string;
    fromDateMin?: string;
    toDateMax?: string;
    toDateMin?: string;
    achievements?: string;

  }

  export interface StudyHistory {
    id: string;
    diploma: string;
    academicLevel: string;
    studyAt: string;
    fromDate: string;
    toDate: string;
    achievements: string;

  }

  export interface StudyHistoryCreateUpdateDto {
    diploma: string;
    academicLevel: string;
    studyAt: string;
    fromDate: string;
    toDate: string;
    achievements: string;

  }
}
