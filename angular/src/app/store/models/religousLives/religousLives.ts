import { ABP } from '@abp/ng.core';


export namespace ReligousLives {
  export interface State {
    religousLives: Response;
  }

  export interface Response {
    items: ReligousLife[];
    totalCount: number;
  }



  export interface ReligousLivesQueryParams extends ABP.PageQueryParams {
    filterText?: string;
    monkId?: string;
    dateOfPractitionersMax?: string;
    dateOfPractitionersMin?: string;
    dateOfThinhVienMax?: string;
    dateOfThinhVienMin?: string;
    dateOfTapVien?: string;
    firstKhan?: string;
    secondKhanMax?: string;
    secondKhanMin?: string;
    thirdKhanMax?: string;
    thirdKhanMin?: string;
    remainKhanMax?: string;
    remainKhanMin?: string;
    lifeTimeKhanMax?: string;
    lifeTimeKhanMin?: string;
    dateOfDeaconMax?: string;
    dateOfDeaconMin?: string;
    dateOfPriestMax?: string;
    dateOfPriestMin?: string;

  }

  export interface ReligousLife {
    id: string;
    monkId: string;
    dateOfPractitioners: string;
    dateOfThinhVien: string;
    dateOfTapVien: string;
    firstKhan: string;
    secondKhan: string;
    thirdKhan: string;
    remainKhan: string;
    lifeTimeKhan: string;
    dateOfDeacon: string;
    dateOfPriest: string;

  }

  export interface ReligousLifeCreateUpdateDto {
    monkId: string;
    dateOfPractitioners: string;
    dateOfThinhVien: string;
    dateOfTapVien: string;
    firstKhan: string;
    secondKhan: string;
    thirdKhan: string;
    remainKhan: string;
    lifeTimeKhan: string;
    dateOfDeacon: string;
    dateOfPriest: string;

  }
}
